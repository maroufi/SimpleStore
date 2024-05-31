using SimpleStore.App.Base;

namespace SimpleStore.App.Products;

[Cachable(60)]
public class ProductPriceQuery : IQuery<Result<ProductPriceResult>>
{
    public long ProductId { get; set; }
}
