using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebContacts.Data;
using WebContacts.Dtos;
using WebContacts.Mappers;
using WebContacts.Models;

namespace WebContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase {
        private readonly AppDBContext _context;
        public ContactsController(AppDBContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts(string lastName) {
            if (!string.IsNullOrEmpty(lastName)) {
                return await _context.Contacts
                    .Where(c => c.LastName.Contains(lastName))
                    .ToListAsync();
            }
            return await _context.Contacts.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact) {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id) {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null) {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
