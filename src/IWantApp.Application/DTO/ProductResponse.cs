using IWantApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.DTO
{

    public record ProductResponse
    (
        Guid Id,
        string Name,
        Guid CategoryId,
        string Description,
        decimal Price,
        bool HasStock
    );


}
