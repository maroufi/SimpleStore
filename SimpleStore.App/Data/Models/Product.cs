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

    private int inventoryCount;
    public int InventoryCount 
    { 
        get { return inventoryCount; } 
        set {
            if(value < 0)
                throw new ArgumentException("InventoryCount should not be negative");
            inventoryCount = value;
        } 
    }

    public decimal Price { get; set; }

    private decimal discount;
    public decimal Discount 
    { 
        get { return discount; }
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Discount should be in zero to 100 range");
            discount = value;
        }
    }

    public decimal FinalPrice => Math.Round(Price - (Price * Discount / 100));
}
