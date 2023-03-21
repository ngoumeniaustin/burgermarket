
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace burger_market.Models
{
    public class Burger
    {
        [JsonIgnore]
        public int BurgerID { get; set; }

        [Display(Name = "Nom")]
        public string nom { get; set; }

        [Display(Name = "Prix")]
        public float prix { get; set; }

        [Display(Name = "Végétarienne")]
        public bool vegetarienne { get; set; }

        [Display(Name = "Ingredients")]
        [JsonIgnore]
        public string ingredients { get; set; }

        [NotMapped]
        [JsonPropertyName("ingredients")]
        public string[] ingredientsList
        {
            get
            {
                if((ingredients == null) || (ingredients.Count() == 0))
                {
                    return null;
                }
                return ingredients.Split(", ");
            }
        }
    }
}
