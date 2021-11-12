using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE3_E_Shopping.Infrastructure
{
    public class EShoppingContext : DbContext
    {
        public EShoppingContext(DbContextOptions<EShoppingContext> options)
            :base(options)
        {

        }
    }
}
