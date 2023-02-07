using Microsoft.EntityFrameworkCore;
using Retailshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retailshop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly APIDbContext _appDBContext;
        public ProductRepository(APIDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _appDBContext.Products.ToListAsync();
        }
        public async Task<Product> GetProductByID(int ID)
        {
            return await _appDBContext.Products.FindAsync(ID);
        }
        public async Task<Product> InsertProduct(Product objProduct)
        {
            _appDBContext.Products.Add(objProduct);
            await _appDBContext.SaveChangesAsync();
            return objProduct;
        }
        public async Task<Product> UpdateProduct(Product objProduct)
        {
            _appDBContext.Entry(objProduct).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objProduct;
        }
        public bool DeleteProduct(int ID)
        {
            bool result = false;
            var product = _appDBContext.Products.Find(ID);
            if (product != null)
            {
                _appDBContext.Entry(product).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }

}
