using Microsoft.EntityFrameworkCore;

namespace EbanxApi.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
