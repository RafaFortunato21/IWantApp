namespace IWantApp.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreateOn { get; set; }
    public string EditedBy { get; set; }
    public DateTime EditedOn { get; set; }
    
}