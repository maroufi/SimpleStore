using SimpleStore.App.Base;

namespace SimpleStore.App.Data.Models;

public class Product
{
    private Product(string? title, int inventoryCount, decimal price, decimal discount)
    {
        Title = title;
        InventoryCount = inventoryCount;
        Price = price;
        Discount = discount;
    }

    public static Result<Product> Create(string? title, int inventoryCount, decimal price, decimal discount)
    {
        if (string.IsNullOrEmpty(title))
            return Result.Fail<Product>("Product title should has value");
        if (title.Length > 40)
            return Result.Fail<Product>("Product title should be less than 40");
        if (inventoryCount < 0)
            return Result.Fail<Product>("InventoryCount should not be negative");
        if (discount < 0 || discount > 100)
            return Result.Fail<Product>("Discount should be in zero to 100 range");

        var product = new Product(title, inventoryCount, price, discount);
        return Result.Ok(product);
    }

    public long Id { get; set; }
    public string? Title { get; set; }
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public decimal FinalPrice => Math.Round(Price - (Price * Discount / 100));
}
