using IWantApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.DTO
{

    public record ProductRequest
    (
        string Name,
        string Description,
        Guid CategoryId,
        decimal Price,
        bool HasStock
    );


}
