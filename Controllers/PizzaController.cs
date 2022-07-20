using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index(){
            List<Pizza> pizze = new PizzaContext().Pizzas.Include(p => p.Category).Include(ing => ing.Ingredients).ToList();
            ViewData["title"] = "Menù pizze";
            return View(pizze);
        }

        public IActionResult Show(int id){
            Pizza pizzaResult = new PizzaContext().Pizzas.Where(pizza => pizza.Id == id).Include(p => p.Category).Include(ing => ing.Ingredients).FirstOrDefault();
            if (pizzaResult == null){
                return NotFound($"Non esiste nessuna pizza con l'id {id}");
            }
            else{
                return View(pizzaResult);

            }
        }

        [HttpGet]
        public IActionResult Create(){

            using(PizzaContext context = new PizzaContext()){
                List<Category> categories = context.Categories.ToList();
                List<Ingrediente> ingredients = context.Ingredients.ToList();

                PizzaCategories model = new PizzaCategories();
                model.Categories = categories;
                model.Pizza = new Pizza();
                model.Ingredients = ingredients;

                return View("Create", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaCategories model){
            using (PizzaContext context = new PizzaContext()){
                if (!ModelState.IsValid){
                    model.Categories = context.Categories.ToList();
                    model.Ingredients = context.Ingredients.ToList();
                    return View("Create", model);
                }

                model.Categories = context.Categories.Where(find => find.Id == model.Pizza.CategoryId).ToList();

                foreach(string ingrediente in model.SelectedIngredients){

                    model.Ingredients = context.Ingredients.Where(name => name.Nome == ingrediente).ToList();
                }
                context.Pizzas.Add(model.Pizza);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
                
            
        }


        [HttpGet]
        public IActionResult Update(int id){

            using (PizzaContext context = new PizzaContext()){
                Pizza pizza = context.Pizzas.Find(id);
                List<Category> categories = context.Categories.ToList();
                List<Ingrediente> ingredients = context.Ingredients.ToList();

                PizzaCategories model = new PizzaCategories();
                model.Categories = categories;
                model.Pizza = pizza;
                model.Ingredients = ingredients;

                //Da vedere perchè non mi passa gli ingredienti della pizza
                model.Pizza.Ingredients = pizza.Ingredients;

                if (pizza == null){
                    return NotFound();
                }

                return View("Update", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //l'id ci serve a trovare la pizza nel db, mentre il model Pizza rappresenta la nuova 
        //entità con i dati modificati dall'utente
        public IActionResult Update(int id, Pizza pizza){ 
            if (!ModelState.IsValid){
                return View("Update", pizza);
            }

            using (PizzaContext context = new PizzaContext()){
                Pizza oldPizza = context.Pizzas.Find(id);

                if(oldPizza == null){
                    return NotFound();
                }

                oldPizza.Nome = pizza.Nome;
                oldPizza.Descrizione = pizza.Descrizione;
                oldPizza.Immagine = pizza.Immagine;
                oldPizza.Prezzo = pizza.Prezzo;
                oldPizza.Category = pizza.Category;
                oldPizza.CategoryId = pizza.CategoryId;

                context.Pizzas.Update(oldPizza);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id){
            using (PizzaContext context = new PizzaContext())
            {

                Pizza pizza = context.Pizzas.Find(id);

                if (pizza == null){
                    return NotFound();
                }

                context.Pizzas.Remove(pizza);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}
