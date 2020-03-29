using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS5.Models;

namespace PS5.Pages
{
    public class ListModel : MyPageModel
    {
       
        public List<Product> productList;
        [BindProperty]
        public int id { get; set; }
        public void OnGet()
        {
            LoadDB();
            productList = productDB.List();
            SaveDB();
        }
        public IActionResult OnPost()
        {
            

            return RedirectToPage("Edit",new { id = id});
        }
        public IActionResult OnPostDelete()
        {
            LoadDB();
            productDB.Delete(id);
            SaveDB();
            return RedirectToPage("List");
        }
    }
}