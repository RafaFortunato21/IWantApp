using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.DTO
{
    public record OrderRequest(List<Guid> ProductIds, string DeliveryAddress);
    
}
