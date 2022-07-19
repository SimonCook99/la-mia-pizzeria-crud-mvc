using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.ValidationAttributes
{
    public class AtLeastFiveWords : ValidationAttribute{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            string descrizione = (string)value;
            int contatoreSpazi = 0;

            //se la descrizione non è vuota, scorro in tutta la stringa e conto gli spazi presenti
            if(descrizione != null){
                foreach (char carattere in descrizione.Trim()){
                    if (carattere.Equals(' '))
                        contatoreSpazi++;
                }
            }

            //se non ci sono abbastanza spazi, allora ci sono meno di 5 parole
            if(contatoreSpazi < 4){
                return new ValidationResult("La descrizione deve avere almeno 5 parole");
            }

            return ValidationResult.Success;

        }
    }
}
