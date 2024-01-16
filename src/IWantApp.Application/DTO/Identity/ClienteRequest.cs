using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.DTO.Identity
{
    public record ClienteRequest
    (
        string Email,
        string Password,
        string Name,
        string CPF
    );
}
