namespace SimpleStore.App.Products;

public class IncreaseInventoryCountCommand : ICommand
{
    public long ProductId { get; set; }
    public int IncreasingValue { get; set; }
}
