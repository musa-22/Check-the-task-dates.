using Microsoft.EntityFrameworkCore;
using Reminder.Model;

namespace Reminder.DATA
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {

        }



        public DbSet<Details> detailsDb { get; set; }

    }
}
