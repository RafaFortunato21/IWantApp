using Azure;
using Dapper;
using IWantApp.Application.Contracts;
using IWantApp.Application.DTO;
using IWantApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbDapper _dapperConnection;

        public EmployeeService(ApplicationDbDapper dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }
        public async Task<IEnumerable<EmployeeResponseDTO>> GetEmployees(int page, int rows)
        {
            var query = @"select Email, ClaimValue as Name 
                    From aspNetUsers u    
                        inner join AspNetuserClaims c    
                            on u.id = c.userId and claimType = 'Name' 
                order by Name
                OFFSET(@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

            return await _dapperConnection.connection.QueryAsync<EmployeeResponseDTO>(
                query, new { page, rows }
            );

        }

        
    }
}
