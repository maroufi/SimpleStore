
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
    }
}