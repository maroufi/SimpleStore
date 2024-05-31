using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace SimpleStore.App.Base;
public class CachingBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IQuery<TResponse>
    where TResponse : notnull, Result
{
    private readonly IMemoryCache _cache;

    public CachingBehavior(
        IMemoryCache cache)
    {
        _cache = cache;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var cachableAttribute = typeof(TRequest).GetCustomAttributes(typeof(CachableAttribute), false).FirstOrDefault() as CachableAttribute;

        if (cachableAttribute == null)
        {
            return await next();
        }
        string cacheKey = GenerateCacheKey(request);

        if (_cache.TryGetValue(cacheKey, out TResponse? cachedResponse))
        {
            if (cachedResponse == null) { throw new Exception("Chached Response is null"); }
            return cachedResponse;
        }

        TResponse response = await next();

        if (response.Failed) return response;
        _cache.Set(cacheKey, response, TimeSpan.FromMinutes(cachableAttribute.DurationInMinutes));

        return response;
    }

    private static string GenerateCacheKey(TRequest request)
    {
        return $"{typeof(TRequest).FullName}_{JsonConvert.SerializeObject(request)}";
    }
}
