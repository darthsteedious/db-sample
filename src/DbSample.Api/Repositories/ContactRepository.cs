using Dapper;
using DbSample.Api.Domain;
using Microsoft.Extensions.Configuration;

namespace DbSample.Api.Repositories
{
    public class ContactRepository
    {
        private readonly IConfiguration configuration;
        private readonly ContactAddressRepository contactAddressRepository;
        private readonly ContactEmailRepository contactEmailRepository;
        private readonly ContactPhoneRepository contactPhoneRepository;

        public ContactRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            contactAddressRepository = new ContactAddressRepository(configuration);
            contactEmailRepository = new ContactEmailRepository(configuration);
            contactPhoneRepository = new ContactPhoneRepository(configuration);
        }

        public Contact GetContactById(int contactId)
        {
            using (var connection = SqlConnectionFactory.GetConnection(configuration))
            {
                const string query = @"
SELECT
    contact_id AS Id,
    first_name as FirstName,
    last_name as LastName,
    birthdate as Birthdate
FROM contact
WHERE contact_id = @Id";

                var contact = connection.QuerySingleOrDefault<Contact>(query, new {Id = contactId});

                contact.Addresses = contactAddressRepository.GetContactAddress(contactId);
                contact.Emails = contactEmailRepository.GetContactEmails(contactId);
                contact.Phones = contactPhoneRepository.GetContactPhones(contactId);
                
                return contact;
            }
        }
    }
}