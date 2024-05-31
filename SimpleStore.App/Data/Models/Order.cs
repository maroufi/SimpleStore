namespace SimpleStore.App.Data.Models;

public class Order
{
    public Order(long buyerId, long productId)
    {
        BuyerId = buyerId;
        ProductId = productId;
        CreationDate = DateTime.UtcNow;
    }

    public long Id { get; set; }
    public long BuyerId { get; set; }
    public User? Buyer { get; set; }
    public long ProductId { get; set; }
    public Product? Product { get; set; }
    public DateTime CreationDate { get; private set; }
}
