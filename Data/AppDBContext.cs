using Microsoft.EntityFrameworkCore;
using WebContacts.Models;

namespace WebContacts.Data
{
    public class AppDBContext : DbContext {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Contact> Contacts {  get; set; }
    }
}
