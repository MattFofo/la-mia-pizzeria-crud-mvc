using la_mia_pizzeria_static.ValidatorAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Alla tua pizza serve un nome!")]
        [StringLength(30)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Alla tua pizza serve una descrizione!")]
        [StringLength(200, ErrorMessage = "Iltesto non può essere così lungo!")]
        [NoMoreThanFiveWordsValidation]
        public string Description { get; set; }

        [Required(ErrorMessage = "Alla tua pizza serve un'immagine!")]
        [Url(ErrorMessage = "Inserisci un URL valido!")]
        public string Image { get; set; }

        [Range(1, 100, ErrorMessage = "Il prezzo deve essere compreso tra {1} e {2}")]
        [Required(ErrorMessage = "Gratis è morto.")]
        public decimal Price { get; set; }

        public Pizza()
        {

        }
        public Pizza(string name, string description, string image, decimal price)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
