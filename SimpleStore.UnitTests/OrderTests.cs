using SimpleStore.App.Data.Models;

namespace SimpleStore.UnitTests;

public class OrderTests
{

    [Fact]
    public void Should_Create_Order_With_Product_And_UserId()
    {
        var order = new Order(1, 1);

        Assert.InRange(order.CreationDate,DateTime.UtcNow.AddSeconds(-1), DateTime.UtcNow.AddSeconds(1));
    }
}