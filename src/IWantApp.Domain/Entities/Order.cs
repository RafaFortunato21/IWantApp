using IWantApp.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Domain.Entities
{
    public class Order : Entity
    {
        public string ClientId { get; set; }
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }
        public string DeliveryAddress { get; set; }

        public Order()
        {
            
        }

        public Order(string clientId, List<Product> products, 
                     decimal total, string deliveryAddress,
                     string clientUserId)
        {
            ClientId = clientId;
            Products = products;
            Total = total;
            DeliveryAddress = deliveryAddress;
            CreatedBy = clientUserId;
            EditedBy = clientUserId;
            CreatedOn = DateTime.UtcNow;
            EditedOn = DateTime.UtcNow;

            Total = 0;

            foreach (var item in Products)
                Total += item.Price;

        }
    }
}
