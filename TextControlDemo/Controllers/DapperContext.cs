using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TextControlDemo.Controllers
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_configuration.GetConnectionString("NpgsqlConnection"));
        public IDbConnection CreateMasterConnection()
            => new NpgsqlConnection(_configuration.GetConnectionString("MasterConnection"));
    }
}
