using la_mia_pizzeria_static.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models{

    public class CheckboxItem{

        public int Id { get; set; }

        public string Nome { get; set; }

        public bool IsChecked { get; set; }
    }
}