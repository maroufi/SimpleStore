using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using SimpleStore.App.Products;
using System.Text;

namespace SimpleStore.IntegrationTests;

public class IncreaseInventoryCountTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    public IncreaseInventoryCountTests(WebApplicationFactory<Program> factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Increase_Product_InventoryCount()
    {
        var command = new IncreaseInventoryCountCommand
        {
            ProductId = 1,
            IncreasingValue = 10
        };
        var serializedValue = JsonConvert.SerializeObject(command);
        var content = new StringContent(serializedValue, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync("/Products", content);
        response.EnsureSuccessStatusCode();
    }
}