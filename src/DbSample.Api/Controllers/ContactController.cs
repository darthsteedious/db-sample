using DbSample.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DbSample.Api.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactRepository contactRepository;
        public ContactController(IConfiguration configuration)
        {
            contactRepository = new ContactRepository(configuration);
        }
        
        [HttpGet("{contactId:int}")]
        public IActionResult GetContactById(int contactId)
        {
            var contact = contactRepository.GetContactById(contactId);

            return Ok(contact);
        }
    }
}