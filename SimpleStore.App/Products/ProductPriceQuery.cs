using MediatR;

namespace SimpleStore.App.Products
{
    public class ProductPriceQuery: IRequest<ProductPriceResult>
    {
        public long ProductId { get; set; }
    }
}
