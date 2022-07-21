using la_mia_pizzeria_static.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models{

    public class Ingrediente{

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        //public bool IsClicked { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public Ingrediente(){

        }
        public Ingrediente(string nome){
            Nome = nome;
        }

    }
}