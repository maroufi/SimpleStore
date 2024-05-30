namespace SimpleStore.App.Data.Models;

public class Product
{
    public Product(string? title, int inventoryCount, decimal price, decimal discount)
    {
        Title = title;
        InventoryCount = inventoryCount;
        Price = price;
        Discount = discount;
    }

    public long Id { get; set; }
    private string? title;
    public string? Title
    {
        get
        {
            return title;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Product title should has value");
            if (value.Length > 40)
                throw new ArgumentException("Product title should be less than 40");
            title = value;
        }
    }
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }

    public decimal FinalPrice => Math.Round(Price - (Price * Discount / 100));
}
