using Microsoft.EntityFrameworkCore;
// required to install Microsoft.EntityFrameworkCore.InMemory

namespace Manipulate_data_API_ex.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }  //constructor 

        public DbSet<Book> Books { get; set; }
    }
}
