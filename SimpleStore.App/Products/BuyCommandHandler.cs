using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleStore.App.Base;
using SimpleStore.App.Data;
using SimpleStore.App.Data.Models;

namespace SimpleStore.App.Products;

public class BuyCommandHandler : IRequestHandler<BuyCommand, Result>
{
    private readonly SimpleStoreDbContext _dbContext;

    public BuyCommandHandler(SimpleStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result> Handle(BuyCommand request, CancellationToken cancellationToken)
    {
        var effectedRows = await _dbContext.Products
            .Where(p => p.Id == request.ProductId && p.InventoryCount > 0)
            .ExecuteUpdateAsync(setPropertyCalls => setPropertyCalls
            .SetProperty(p => p.InventoryCount, p => p.InventoryCount - 1),
            cancellationToken: cancellationToken);

        if (effectedRows == 0)
            return Result.Fail("The product is out of stock");

        _dbContext.Orders.Add(new Order(request.BuyerId, request.ProductId));

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
