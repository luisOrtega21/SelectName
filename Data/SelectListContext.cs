using Microsoft.EntityFrameworkCore;
using SelectExample.Models;

namespace SelectExample.Data
{
    public class SelectListContext :DbContext
    {
        public SelectListContext(DbContextOptions<SelectListContext> options): base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
