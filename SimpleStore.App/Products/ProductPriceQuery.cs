﻿namespace SimpleStore.App.Products;

public class ProductPriceQuery: IQuery<ProductPriceResult>
{
    public long ProductId { get; set; }
}
