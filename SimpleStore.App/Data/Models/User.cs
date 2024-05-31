namespace SimpleStore.App.Data.Models;

public class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
