using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab28LoginAuth.Models;



namespace Lab28LoginAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lab28LoginAuthContext _context;

        public HomeController(Lab28LoginAuthContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.RecipeModel;

            return View(result.ToList());
        }

    }
}