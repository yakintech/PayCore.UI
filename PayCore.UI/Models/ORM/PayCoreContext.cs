using Microsoft.EntityFrameworkCore;

namespace PayCore.UI.Models.ORM
{
    public class PayCoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EET2RGT; Database=PayCoreBookDB; trusted_connection=true");
        }


        public DbSet<Book> Books { get; set; }
    }
}
