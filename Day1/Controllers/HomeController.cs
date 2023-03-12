using Day1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Day1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModelProduct pro;

        public HomeController(ModelProduct _pro)
        {
            pro = _pro;
        }
        public IActionResult GetAll()
        {
            return View("index", pro.GetAll());
        }
        public IActionResult GetByID(int id)
        {
            product p = new product();
            p.id = 10;
            p.name = "aa";
            return View("ONEPRODUCT", pro.GetByID(id));
        }
    }
}
