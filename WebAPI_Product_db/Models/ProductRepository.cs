using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Product_db.Models
{
    public class ProductRepository : IProductRepository
    {
        List<Product> products = new List<Product>();
        private int _nextID = 1;

        public ProductRepository()
        {
            MyProductsEntities entities = new MyProductsEntities();
            var test = entities.Products;
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }
        public Product GetProduct(int ID){
            return products.Find(p => p.ID == ID);
        }
        public Product AddProduct(Product item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }
            item.ID = _nextID++;
            products.Add(item);
            return item;
        }
        public void RemoveProduct(int ID)
        {
            products.RemoveAll(p => p.ID == ID);
        }
        public bool UpdateProduct(Product item)
        {
            if (item == null)
                throw new ArgumentNullException();
            int index = products.FindIndex(p => p.ID == item.ID);

            if (index == -1)
                return false;

            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}