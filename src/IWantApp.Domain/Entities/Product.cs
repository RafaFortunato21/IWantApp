using IWantApp.Domain.Shared;

namespace IWantApp.Domain.Entities;

public class Product : Entity
{
    public string Description { get; set; }
    public int? CategoryId { get; set; }
    public Category Categoria { get; set; }
    public bool HasStock { get; set; }

}
