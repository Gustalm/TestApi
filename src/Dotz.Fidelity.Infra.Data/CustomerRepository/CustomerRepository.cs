using Dapper;
using Dotz.Fidelity.CrossCutting.Options;
using Dotz.Fidelity.Domain.Aggregates.Customer;
using Dotz.Fidelity.Domain.Repositories;
using Dotz.Fidelity.Infra.Data.Statements;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Dotz.Fidelity.Infra.Data.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;
        private readonly ConnectionStringOption _connectionString;

        public CustomerRepository(
                          ILogger<CustomerRepository> logger,
                          IOptions<ConnectionStringOption> connectionString)
        {
            _logger = logger;
            _connectionString = connectionString.Value;
        }

        public Task<Customer> Get(string email)
        {
            using (var conn = new MySqlConnection(_connectionString.ConnectionString))
            {
                return conn.QueryFirstOrDefaultAsync<Customer>(CustomerStatements.GetByEmail, email);
            }
        }

        public Task<Customer> Get(int id)
        {
            using (var conn = new MySqlConnection(_connectionString.ConnectionString))
            {
                return conn.QueryFirstOrDefaultAsync<Customer>(CustomerStatements.GetById, id);
            }
        }

        public async Task<Customer> Register(Customer customer)
        {
            using (var conn = new MySqlConnection(_connectionString.ConnectionString))
            {
                var paramList = new DynamicParameters(customer);
                paramList.Add(name: "Id", dbType: DbType.Int64, direction: ParameterDirection.Output);

                customer.SetId(await conn.ExecuteScalarAsync<int>(CustomerStatements.InsertCustomer, paramList));
            }

            return customer;
        }

        public Task<Customer> RegisterAddress(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
