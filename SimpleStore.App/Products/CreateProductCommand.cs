using SimpleStore.App.Base;

namespace SimpleStore.App.Products;

public class CreateProductCommand : ICommand<Result>
{
    public string? Title { get; set; }
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}
