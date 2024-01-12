using IWantApp.Domain.Shared;

namespace IWantApp.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? CategoryId { get; set; }
    public Category Categoria { get; set; }
    public bool HasStock { get; set; }

}
