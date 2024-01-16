using IWantApp.Domain.Shared;

namespace IWantApp.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public Guid? CategoryId { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public bool HasStock { get; set; }
    public decimal Price { get; set; }
    public ICollection<Order> Orders { get; set; }

}
