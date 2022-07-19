using la_mia_pizzeria_static.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza{

        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo seguente è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il campo seguente non deve superare i 50 caratteri")]
        public string Nome { get; set; }

        [Column(TypeName = "Text")]
        [StringLength(300, ErrorMessage = "Il campo seguente non deve superare i 300 caratteri")]


        [AtLeastFiveWords]
        public string? Descrizione { get; set; }
        public string? Immagine { get; set; }

        [Required(ErrorMessage = "Il campo seguente è obbligatorio")]
        [Range(1,99)]
        public double Prezzo { get; set; }

        public Pizza(string nome, string descrizione, string immagine, double prezzo){
            Nome = nome;
            Descrizione = descrizione;
            Immagine = immagine;
            Prezzo = prezzo;
        }

        public Pizza(){

        }
    }
}