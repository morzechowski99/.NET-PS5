using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS5.Models
{
    public class MyPageModel : PageModel
    {
        public ProductDB productDB;
        public string jsonProductDB { get; set; }
        public MyPageModel()
        {
            productDB = new ProductDB();
        }
        public void LoadDB()
        {
            jsonProductDB = HttpContext.Session.GetString("jsonProductDB");
            productDB.Load(jsonProductDB);
        }
        public void SaveDB()
        {
            jsonProductDB = productDB.Save();
            HttpContext.Session.SetString("jsonProductDB", jsonProductDB);
        }
    }
}
