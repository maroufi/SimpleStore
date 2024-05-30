
using SimpleStore.App.Data.Models;

namespace SimpleSales.UnitTests
{
    public class ProductTests
    {

        [Fact]
        public void Should_Create_Product_With_Title()
        {
            var result = Assert.Throws<ArgumentException>(() =>
            {
                new Product(null, 0, 3000, 0.33m);
            });

            Assert.Contains("title", result.Message);
        }
        [Fact]
        public void Should_Not_Create_Product_With_Empty_Or_Null_Title()
        {
            var result = Assert.Throws<ArgumentException>(() =>
            {
                new Product(null, 0, 3000, 0.33m);
            });

            Assert.Contains("title",result.Message);
        }

        [Fact]
        public void Should_Calculate_Product_Applied_Discount_Price()
        {
            var product = new Product("Sushi", 0, 100_000_000, 33);

            Assert.Equal(67_000_000m, product.FinalPrice);
        }

        [Fact]
        public void Should_Calculate_Product_Applied_Discount_Price_With_Has_Scale_Discount()
        {
            var product = new Product("Sushi", 0, 100_000_000, 33.33m);

            Assert.Equal(66_670_000m, product.FinalPrice);
        }

        [Fact]
        public void Should_Calculate_Product_Applied_Discount_Price_With_Rounding_Up()
        {
            var product = new Product("Sushi", 0, 100, 33.33m);

            Assert.Equal(67m, product.FinalPrice);
        }

        [Fact]
        public void Should_Calculate_Product_Applied_Discount_Price_With_Rounding_Down()
        {
            var product = new Product("Sushi", 0, 100, 66.66m);

            Assert.Equal(33m, product.FinalPrice);
        }
    }
}