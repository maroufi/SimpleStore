using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SimpleStore.App.Data;

namespace SimpleStore.App.Products;

public class IncreaseInventoryCountCommandHandler :
    IRequestHandler<IncreaseInventoryCountCommand>
{
    private readonly SimpleStoreDbContext _dbContext;

    public IncreaseInventoryCountCommandHandler(SimpleStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(IncreaseInventoryCountCommand request, CancellationToken cancellationToken)
    {
        string sql = "UPDATE Products SET InventoryCount = InventoryCount + @increasingValue WHERE Id = @productId";

        await _dbContext.Database.ExecuteSqlRawAsync(sql, 
            new SqlParameter("@increasingValue", request.IncreasingValue),
            new SqlParameter("@productId", request.ProductId));
    }
}
