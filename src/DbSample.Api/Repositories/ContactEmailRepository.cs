using System.Collections.Generic;
using Dapper;
using DbSample.Api.Domain;
using Microsoft.Extensions.Configuration;

namespace DbSample.Api.Repositories
{
    public class ContactEmailRepository
    {
        private readonly IConfiguration configuration;

        public ContactEmailRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<ContactEmail> GetContactEmails(int contactId)
        {
            using (var connection = SqlConnectionFactory.GetConnection(configuration))
            {
                const string query = @"
SELECT 
    contact_email_id AS Id,
    email as Email
FROM contact_email
WHERE contact_id = @ContactId";

                return connection.Query<ContactEmail>(query, new {ContactId = contactId});
            }
        }
    }
}