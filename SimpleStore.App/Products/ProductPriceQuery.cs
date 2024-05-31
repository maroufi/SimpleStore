using SimpleStore.App.Base;

namespace SimpleStore.App.Products;

public class ProductPriceQuery: IQuery<Result<ProductPriceResult>>
{
    public long ProductId { get; set; }
}
