using SimpleStore.App.Base;

namespace SimpleStore.App.Products;

[Transactional]
public class BuyCommand : ICommand<Result>
{
    public long ProductId { get; set; }
    public long BuyerId { get; set; }
}
