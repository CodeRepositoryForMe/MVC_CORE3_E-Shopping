using Microsoft.EntityFrameworkCore;
using MVC_CORE3_E_Shopping.Models;

namespace MVC_CORE3_E_Shopping.Infrastructure
{
    public class EShoppingContext : DbContext
    {
        public EShoppingContext(DbContextOptions<EShoppingContext> options)
            :base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }
    }
}
