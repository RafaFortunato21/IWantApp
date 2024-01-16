using IWantApp.Application.DTO;
using IWantApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDTO>> GetEmployees(int page, int rows);
        
        
    }
}
