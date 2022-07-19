using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    public class EserciziRazor : Controller{
  
        public IActionResult Index()
        {
            return View();
        }
    }
}