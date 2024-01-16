using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.Contracts
{
    public interface IUserIdentityService
    {
        Task<(IdentityResult, string)> CreateUserAsync(string email, string password, List<Claim> claims);
    }
}
