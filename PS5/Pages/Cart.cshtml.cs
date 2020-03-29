using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS5.Models;

namespace PS5.Pages
{
    public class CartModel : MyPageModel
    {
        public class Element
        {
            public Product product { get; set; }
            public int count { get; set; }

            public Element(Product product, int count)
            {
                this.product = product;
                this.count = count;
            }

           
            
        }
        public decimal ValueOfCart()
        {
            decimal value = 0M;
            foreach(Element el in elements)
            {
                value += (el.count * el.product.price);
            }
            return value;
        }
        public List<Element> elements;
        public void OnGet()
        {
            CreateCart();
        }
        private void CreateCart()
        {
            LoadDB();
            var cookieValue = Request.Cookies["Cart"];
            if (cookieValue != null)
            {
                string[] ids = cookieValue.Split(null);
                elements = new List<Element>();
                Element el = null;
                foreach (string id in ids)
                {
                    if (id != "")
                    {
                        int idd = Convert.ToInt32(id);
                        if ((el=Find(idd)) != null)
                        {
                            el.count++;
                        }
                        else
                        {
                            Product p = productDB.GetProductByID(idd);
                            if (p != null)
                            {
                                elements.Add(new Element(p, 1));
                            }
                        }
                    }
                }
            }

        }
        private Element Find(int id)
        {
            foreach(Element el in elements)
            {
                if (el.product.id == id) return el;
            }
            return null;
        }
        public IActionResult OnPost()
        {
            Response.Cookies.Append("Cart", "");
            return RedirectToPage("Cart");
        }
    }
}