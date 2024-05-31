using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SimpleStore.App.Base;

namespace SimpleStore.App.Pipes;
public class CachingBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> 
    where TRequest : notnull, IQuery<TResponse> 
    where TResponse : notnull
{
    private readonly IMemoryCache _cache;

    public CachingBehavior(
        IMemoryCache cache)
    {
        _cache = cache;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var cachKey = $"{typeof(TRequest).Name}_{JsonConvert.SerializeObject(request)}";

        if (_cache.TryGetValue(cachKey, out TResponse? cachedResponse))
        {
            if (cachedResponse == null) { throw new Exception("Chached Response is null"); }
            return cachedResponse;
        }

        TResponse response = await next();

        _cache.Set(cachKey, response);

        return response;
    }
}
