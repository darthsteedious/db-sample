using DbSample.Api.Domain;
using DbSample.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DbSample.Api.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactRepository contactRepository;
        public ContactController(IConfiguration configuration)
        {
            contactRepository = new ContactRepository(configuration);
        }
        
        [HttpGet("api/[controller]/{contactId:int}")]
        public IActionResult GetContactById(int contactId)
        {
            var contact = contactRepository.GetContactById(contactId);

            return Ok(contact);
        }

        [HttpGet("[controller]/create")]
        public IActionResult Create()
        {
            return View(new Contact());
        }

        [HttpGet("[controller]/edit/{contactId:int}")]
        public IActionResult Edit(int contactId)
        {
            if (contactId == 0)
                return BadRequest("contactId should be non-zero");
            
            var contact = contactRepository.GetContactById(contactId);
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost("[controller]/create")]
        public IActionResult PostContact([FromForm] Contact contact)
        {
            var contactId = contactRepository.CreateContact(contact);

            return RedirectToAction(nameof(Edit), new { contactId });
        }
    }
}