using Microsoft.AspNetCore.Mvc;
using MVC_CORE3_E_Shopping.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE3_E_Shopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        
        public string Index()
        {
            return "Test";
        }
    }
}
