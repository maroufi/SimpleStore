using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using SimpleStore.App.Products;
using System.Net;
using System.Text;

namespace SimpleSales.Tests;

public class AddProductTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    public AddProductTests(WebApplicationFactory<Program> factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Add_Product_With_Predefined_InventoryCount()
    {
        var createProductCommand = new CreateProductCommand
        {
            Title = "Test",
            Discount = 10,
            InventoryCount = 10,
            Price = 33_000_000,
        };
        var serializedValue = JsonConvert.SerializeObject(createProductCommand);
        var content = new StringContent(serializedValue, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/Products", content);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Should_Return_Bad_Request_On_Adding_Product_With_Title_More_Than_40Chars()
    {
        var createProductCommand = new CreateProductCommand
        {
            Title = ManipulateString(50,'i'),
            Discount = 10,
            InventoryCount = 10,
            Price = 33,
        };
        var serializedValue = JsonConvert.SerializeObject(createProductCommand);
        var content = new StringContent(serializedValue, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/Products", content);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    private static string ManipulateString(int n, char c)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            sb.Append(c);
        }

        return sb.ToString();
    }

    [Fact]
    public void Should_Return_OK_Result_On_Adding_Product_With_Unique_Title()
    {

    }

    [Fact]
    public void Should_Return_Bad_Request_On_Adding_Product_With_Not_Unique_Title()
    {

    }
}