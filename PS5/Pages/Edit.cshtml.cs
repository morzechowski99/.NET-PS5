using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS5.Models;

namespace PS5.Pages
{
    public class EditModel : MyPageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty]
        public Product product { get; set; }
        
        public void OnGet()
        {
            LoadDB();
            product = productDB.GetProductByID(id);
            SaveDB();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            LoadDB();
            product.id = id;
            productDB.Replace(id,product);
            SaveDB();
            return RedirectToPage("List");
        }
    }
}