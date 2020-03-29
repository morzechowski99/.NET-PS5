using PS5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace PS5.DAL
{
    public class ProductDB
    {
        private List<Product> products;
        private static int lastIndex;
        public void Load(string jsonProducts)
        {
            if (jsonProducts == null)
            {
                products = Product.GetProducts();
                
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
                
            }
            if(products.Count > 0)
            {
                if (products[products.Count - 1].id > lastIndex)
                    lastIndex = products[products.Count - 1].id;
            }
        }

        private int GetNextId()
        {
            return ++lastIndex;
        }
        public void Create(Product p)
        {
            p.id = GetNextId();
            products.Add(p);
        }
        public void Replace(int id,Product p)
        {
            int idd = products.FindIndex(p => p.id == id);
            products[idd] = p;
        }
        public string Save()
        {

            return JsonConvert.SerializeObject(products);
        }
        public List<Product> List()
        {
            return products;
        }
        public Product GetProductByID(int id)
        {
            return products.Find(p => p.id == id);
        }
        public void Delete(int id)
        {
            products.Remove(GetProductByID(id));
        }
    }
}
