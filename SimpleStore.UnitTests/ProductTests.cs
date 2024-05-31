using SimpleStore.App.Data.Models;
using System.Text;

namespace SimpleSales.UnitTests
{
    public class ProductTests
    {

        [Fact]
        public void Should_Create_Product_With_Title()
        {
            var result = Product.Create("TestTitle", 0, 3000, 0.33m);

            Assert.False(result.Failed);
        }
        [Fact]
        public void Should_Not_Create_Product_With_Empty_Or_Null_Title()
        {
            var result = Product.Create(null, 0, 3000, 0.33m);

            Assert.True(result.Failed);
            Assert.Contains("title", result.Message);
        }
        [Fact]
        public void Should_Not_Create_Product_With_Title_More_Than_40Chars()
        {
            var result = Product.Create(ManipulateString(50,'c'), 0, 3000, 0.33m);

            Assert.True(result.Failed);
            Assert.Contains("title", result.Message);
        }
        private static string ManipulateString(int n, char c)
        {
            StringBuilder sb = new();

            for (int i = 0; i < n; i++)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
        [Fact]
        public void Should_Calculate_Product_Applied_Discount_Price()
        {
            var result = Product.Create("Sushi", 0, 100_000_000, 33);

            Assert.False(result.Failed);
            Assert.Equal(67_000_000m, result.Data.FinalPrice);
        }

        [Fact]
        public void Should_Calculate_Product_Applied_Discount_Price_With_Has_Scale_Discount()
        {
            var result = Product.Create("Sushi", 0, 100_000_000, 33.33m);

            Assert.False(result.Failed);
            Assert.Equal(66_670_000m, result.Data.FinalPrice);
        }

        [Fact]
        public void Should_Calculate_Product_Applied_Discount_Price_With_Rounding_Up()
        {
            var result = Product.Create("Sushi", 0, 100, 33.33m);

            Assert.False(result.Failed);
            Assert.Equal(67m, result.Data.FinalPrice);
        }

        [Fact]
        public void Should_Calculate_Product_Applied_Discount_Price_With_Rounding_Down()
        {
            var result = Product.Create("Sushi", 0, 100, 66.66m);

            Assert.False(result.Failed);
            Assert.Equal(33m, result.Data.FinalPrice);
        }
    }
}