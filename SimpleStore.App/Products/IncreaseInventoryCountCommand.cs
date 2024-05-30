using MediatR;

namespace SimpleStore.App.Products
{
    public class IncreaseInventoryCountCommand : IRequest
    {
        public long ProductId { get; set; }
        public int IncreasingValue { get; set; }
    }
}
