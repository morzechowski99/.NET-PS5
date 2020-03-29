using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PS5.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        [Required]
        public int id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage ="Nazwa jest wymagana")]
        public string name { get; set; }
        [Display(Name = "Cena")]
        [Required(ErrorMessage ="Cena jest wymagana")]
        [Range(0,Double.MaxValue,ErrorMessage = "Cena musi być dodatnia")]
        public decimal price { get; set; }
        public static List<Product> GetProducts()
        {
            Product pilka = new Product
            {
                id = 1,
                name = "Piłka nożna",
                price = 25.30M
            };
            Product narty = new Product { id = 2, name = "Narty", price = 150.39M };
            Product rakieta = new Product { id = 3, name = "Rakieta ", price = 111.10M };
            return new List<Product> { pilka, narty, rakieta };
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   id == product.id;
        }

    }
}
