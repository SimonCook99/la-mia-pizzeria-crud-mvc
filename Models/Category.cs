using la_mia_pizzeria_static.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models{

    public class Category{

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }


        public List<Pizza> Pizzas { get; set; }

        public Category(string nome){
            Nome = nome;
        }

        public Category(){

        }
    }
}