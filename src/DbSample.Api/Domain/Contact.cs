using System;
using System.Collections.Generic;

namespace DbSample.Api.Domain
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        
        public IEnumerable<ContactAddress> Addresses { get; set; }
        public IEnumerable<ContactEmail> Emails { get; set; }
        public IEnumerable<ContactPhone> Phones { get; set; }
    }
}