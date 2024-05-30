using MediatR;
using SimpleStore.App.Data.Models;

namespace SimpleStore.App.Products;

public class CreateProductCommand : IRequest<Product>
{
    public string? Title { get; set; }
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}
