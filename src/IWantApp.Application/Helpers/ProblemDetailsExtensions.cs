using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.Helpers
{
    public static class ProblemDetailsExtensions
    {
        public static Dictionary<string, string[]> ConvertToProblemDetails(this IEnumerable<IdentityError> error)
        {
            return error
                .GroupBy(g => g.Code)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Description).ToArray());
        }
    }
}
