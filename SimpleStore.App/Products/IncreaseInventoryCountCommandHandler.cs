using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.App.Base;
using SimpleStore.App.Data;

namespace SimpleStore.App.Products;

public class IncreaseInventoryCountCommandHandler :
    IRequestHandler<IncreaseInventoryCountCommand, Result>
{
    private readonly SimpleStoreDbContext _dbContext;

    public IncreaseInventoryCountCommandHandler(SimpleStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result> Handle(IncreaseInventoryCountCommand request, CancellationToken cancellationToken)
    {
        var effectedRows = await _dbContext.Products
            .Where(p => p.Id == request.ProductId)
            .ExecuteUpdateAsync(setPropertyCalls => setPropertyCalls
            .SetProperty(p => p.InventoryCount, p => p.InventoryCount + request.IncreasingValue),
            cancellationToken: cancellationToken);

        if (effectedRows == 0) return Result.Fail("Product not found");
        return Result.Ok();
    }
}
