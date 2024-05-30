using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SimpleStore.App.Products;
using System.Text;

namespace SimpleStore.IntegrationTests;

public class GetProductTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    public GetProductTests(WebApplicationFactory<Program> factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Get_Product_With_Applied_Discount_Price()
    {
        var response = await _httpClient.GetAsync("/Products/1");

        Assert.NotNull(response);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ProductPriceResult>(content);

        Assert.Equal(29_700_000, result?.Price);
        response.EnsureSuccessStatusCode();
    }
}
