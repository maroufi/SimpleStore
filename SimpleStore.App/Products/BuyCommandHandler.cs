using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SimpleStore.App.Data;
using SimpleStore.App.Data.Models;

namespace SimpleStore.App.Products
{
    public class BuyCommandHandler : IRequestHandler<BuyCommand>
    {
        private readonly SimpleStoreDbContext _dbContext;

        public BuyCommandHandler(SimpleStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(BuyCommand request, CancellationToken cancellationToken)
        {
            string sql = "UPDATE Products SET InventoryCount = InventoryCount - 1 WHERE Id = @productId";

            await _dbContext.Database.ExecuteSqlRawAsync(sql,
                new SqlParameter("@productId", request.ProductId));

            _dbContext.Orders.Add(new Order(request.BuyerId, request.ProductId));

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
