using System.Collections.Generic;
using Dapper;
using DbSample.Api.Domain;
using Microsoft.Extensions.Configuration;

namespace DbSample.Api.Repositories
{
    public class ContactAddressRepository
    {
        private readonly IConfiguration configuration;

        public ContactAddressRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public IEnumerable<ContactAddress> GetContactAddress(int contactId)
        {
            using (var connection = SqlConnectionFactory.GetConnection(configuration))
            {
                const string query = @"
SELECT 
    contact_address_id as Id,
    line_1 as Line1,
    line_2 as Line2,
    city as City,
    state as State
FROM contact_address
WHERE contact_id = @ContactId";

                return connection.Query<ContactAddress>(query, new {ContactId = contactId});
            }
        }
    }
}