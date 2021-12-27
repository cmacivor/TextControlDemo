using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextControlDemo.Entities;

namespace TextControlDemo.Repositories
{
    public class TxDocumentRepository : ITxDocumentRepository
    {
        private readonly IConfiguration _configuration;

        public TxDocumentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Create(TXDocument document)
        {
            var connString = _configuration.GetValue<string>("ConnectionStrings:NpgsqlConnection");
            using var connection = new NpgsqlConnection(connString);

            string sql = @"INSERT INTO public.""TxDocument"" (""Name"", ""UniqueId"") VALUES(@Name, @UniqueId)";
            var affected = connection.Execute(sql, new { Name = document.Name, UniqueId = document.UniqueId });

            if (affected == 0)
                return false;
            return true;
        }

        public TXDocument Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TXDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
