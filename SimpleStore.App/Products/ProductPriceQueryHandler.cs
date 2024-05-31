using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SimpleStore.App.Data;

namespace SimpleStore.App.Products;

public class ProductPriceQueryHandler : IRequestHandler<ProductPriceQuery, ProductPriceResult>
{
    private readonly SimpleStoreDbContext _dbContext;
    private readonly IMemoryCache _cache;

    public ProductPriceQueryHandler(
        SimpleStoreDbContext dbContext,
        IMemoryCache cache)
    {
        _dbContext = dbContext;
        _cache = cache;
    }
    public async Task<ProductPriceResult> Handle(ProductPriceQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
            .Where(product => product.Id == request.ProductId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (product == null) throw new Exception("NotFound");

        return new ProductPriceResult
        {
            Price = product.FinalPrice,
            ProductId = product.Id
        };
    }
}
