using System.Collections.Generic;
using Dapper;
using DbSample.Api.Domain;
using Microsoft.Extensions.Configuration;

namespace DbSample.Api.Repositories
{
    public class ContactPhoneRepository
    {
        private readonly IConfiguration configuration;

        public ContactPhoneRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<ContactPhone> GetContactPhones(int contactId)
        {
            using (var connection = SqlConnectionFactory.GetConnection(configuration))
            {
                const string query = @"
SELECT
    contact_phone_id AS Id,
    phone_number as PhoneNumber
FROM contact_phone
WHERE contact_id = @ContactId";

                return connection.Query<ContactPhone>(query, new {ContactId = contactId});
            }
        }
    }
}