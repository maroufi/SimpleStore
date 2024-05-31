namespace SimpleStore.App.Products;

public class CreateProductCommand : ICommand
{
    public string? Title { get; set; }
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}
