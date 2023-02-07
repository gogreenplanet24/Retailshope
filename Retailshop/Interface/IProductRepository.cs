using Retailshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retailshop.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetProductByID(int ID);
        Task<Product> InsertProduct(Product objProduct);
        Task<Product> UpdateProduct(Product objProduct);
        bool DeleteProduct(int ID);
    }
}
