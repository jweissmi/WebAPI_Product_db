using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Product_db.Models
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetProduct(int ID);
        Product AddProduct(Product item);
        void RemoveProduct(int ID);
        bool UpdateProduct(Product item);

    }
}
