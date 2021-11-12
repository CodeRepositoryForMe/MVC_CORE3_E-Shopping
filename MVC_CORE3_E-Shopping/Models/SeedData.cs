using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_CORE3_E_Shopping.Infrastructure;
using System;
using System.Linq;

namespace MVC_CORE3_E_Shopping.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EShoppingContext(
                serviceProvider.GetRequiredService<DbContextOptions<EShoppingContext>>()))
            {
                if (context.Pages.Any())
                {
                    return;
                }

                context.Pages.AddRange(
                        new Page
                        {
                            Title = "Home",
                            Slug = "home",
                            Content = "home Page",
                            Sorting = 0
                        },
                        new Page
                        {
                            Title = "About Us",
                            Slug = "aboutus",
                            Content = "About Us Page",
                            Sorting = 100
                        },
                        new Page
                        {
                            Title = "Services",
                            Slug = "services",
                            Content = "Service Page",
                            Sorting = 100
                        },
                        new Page
                        {
                            Title = "Content",
                            Slug = "content",
                            Content = "Content Page",
                            Sorting = 100
                        }
                    );
                context.SaveChanges();
            }
        }
    }
}
