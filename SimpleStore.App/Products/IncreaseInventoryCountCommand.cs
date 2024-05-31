using SimpleStore.App.Base;

namespace SimpleStore.App.Products;

public class IncreaseInventoryCountCommand : ICommand<Result>
{
    public long ProductId { get; set; }
    public int IncreasingValue { get; set; }
}
