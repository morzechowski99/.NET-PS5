using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS5.Models;

namespace PS5.Pages
{
    public class DetailsModel : MyPageModel
    {
        [BindProperty]
        public Product product { get; set; }
        public void OnGet()
        {
            LoadDB();
            product = productDB.GetProductByID(Convert.ToInt32(Request.Query["id"]));
            SaveDB();
        }
        public IActionResult OnPost()
        {
            var cookieValue = Request.Cookies["Cart"];
            if(cookieValue == null)
            {
                Response.Cookies.Append("Cart", $"{product.id} ");
            }
            else
            {
                Response.Cookies.Append("Cart", $"{cookieValue} {product.id} ");
            }
            return RedirectToPage("Details",new { id = product.id});
        }
    }
}