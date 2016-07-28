using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Product_db.Models;

namespace WebAPI_Product_db.Controllers
{
    public class ValuesController : ApiController
    {
        ProductRepository repository = new ProductRepository();

        // GET api/values
        public IEnumerable<Product> GetAll()
        {
            return repository.GetAll();
        }

        // GET api/values/5
        public Product GetProduct(int ID)
        {
            Product item = repository.GetProduct(ID);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return item;
        }

        // POST api/values
        public Product PostProduct(Product item)
        {
            item = repository.AddProduct(item);
            return item;
        }

        // PUT api/values/5
        public Product PutProduct(int ID, Product item)
        {
            item.ID = 10;
            if (!repository.UpdateProduct(item))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return item;
        }

        // DELETE api/values/5
        public void DeleteProduct(int ID)
        {
            Product item = repository.GetProduct(ID);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            repository.RemoveProduct(ID);
        }
    }
}
