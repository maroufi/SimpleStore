namespace SimpleStore.App.Products;

public class BuyCommand : ICommand
{
    public long ProductId { get; set; }
    public long BuyerId { get; set; }
}
