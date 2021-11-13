using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CORE3_E_Shopping.Infrastructure;
using MVC_CORE3_E_Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE3_E_Shopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly EShoppingContext context;

        public PagesController(EShoppingContext context)
        {
            this.context = context;
        }

        //GET / admin/pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in context.Pages orderby p.Sorting select p;

            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }

        // GET /admin/pages/details/{id}
        public async Task<IActionResult> Details(int id)
        {
            Page page = await context.Pages.FirstOrDefaultAsync(x => x.ID == id);
            if (page == null)
                return NotFound();
            return View(page);
        }

        //Get /admin/pages/create
        public IActionResult Create() => View();

        // POST /admin/page/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if(ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var existSlug = await context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);

                if(existSlug != null)
                {
                    ModelState.AddModelError("", "The Title aready exist");
                    return View(page);
                }

                context.Add(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "The page has been added !!";
                return RedirectToAction("Index");

            }

            return View(page);
        }


    }
}
