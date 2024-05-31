using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SimpleStore.App.Products;
using System.Text;

namespace SimpleStore.IntegrationTests;

public class BuyTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    public BuyTests(WebApplicationFactory<Program> factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Buy_Product_For_Predefined_User_1()
    {
        var command = new BuyCommand
        {
            BuyerId = 1,
            ProductId = 1
        };
        var serializedValue = JsonConvert.SerializeObject(command);
        var content = new StringContent(serializedValue, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/Buy", content);
        response.EnsureSuccessStatusCode();
    }
}