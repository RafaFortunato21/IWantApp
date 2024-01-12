using Flunt.Validations;
using IWantApp.Domain.Shared;

namespace IWantApp.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; }



    public Category(string name)
    {
        var contract = new Contract<Category>()
            .IsNotNull(name, "Name");
        
        AddNotifications(contract);


        Name = name;
        Active = true;
    }

}