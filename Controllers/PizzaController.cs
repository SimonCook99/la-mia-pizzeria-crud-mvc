using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index(){
            List<Pizza> pizze = new PizzaContext().Pizzas.ToList();
            ViewData["title"] = "Menù pizze";
            return View(pizze);
        }

        public IActionResult Show(int id){
            Pizza pizzaResult = new PizzaContext().Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();
            if (pizzaResult == null){
                return NotFound($"Non esiste nessuna pizza con l'id {id}");
            }
            else{
                return View(pizzaResult);

            }
        }

        [HttpGet]
        public IActionResult Create(){
            return View("Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza){
            if (!ModelState.IsValid){
                return View("Create", pizza);
            }

            using(PizzaContext context = new PizzaContext()){
                context.Pizzas.Add(pizza);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
