using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Infra.Data.Context
{
    public class ApplicationDbDapper
    {

        public IDbConnection connection;

        public ApplicationDbDapper(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        }

    }
}
