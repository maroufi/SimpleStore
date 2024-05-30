using MediatR;
using SimpleStore.App.Data;
using SimpleStore.App.Data.Models;

namespace SimpleStore.App.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly SimpleStoreDbContext _dbContext;

    public CreateProductCommandHandler(SimpleStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Title,
            request.InventoryCount,
            request.Price,
            request.Discount
        );

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
