using MediatR;
using SimpleStore.App.Base;
using SimpleStore.App.Data;
using SimpleStore.App.Data.Models;

namespace SimpleStore.App.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result>
{
    private readonly SimpleStoreDbContext _dbContext;

    public CreateProductCommandHandler(SimpleStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = Product.Create(
            request.Title,
            request.InventoryCount,
            request.Price,
            request.Discount
        );
        if(result.Failed) return result;

        _dbContext.Products.Add(result.Data);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
