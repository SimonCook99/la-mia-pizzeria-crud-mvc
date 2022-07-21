namespace la_mia_pizzeria_static.Models
{
    public class PizzaCategories{
        public Pizza Pizza { get; set; }

        public List<Category>? Categories { get; set; }

        public List<CheckboxItem>? Ingredients { get; set; }

        //public List<string>? SelectedIngredients { get; set; }
    }
}
