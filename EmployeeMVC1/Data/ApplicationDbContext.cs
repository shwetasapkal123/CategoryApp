using EmployeeMVC1.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC1.Data
{
    //using Code first approach
    public class ApplicationDbContext:DbContext
    {
        //ctor +tab button twice
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {

        }
        public DbSet<Category> categories { get; set; }
    }
}
