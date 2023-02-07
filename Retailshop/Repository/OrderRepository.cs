using Microsoft.EntityFrameworkCore;
using Retailshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retailshop.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly APIDbContext _appDBContext;
        public OrderRepository(APIDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await _appDBContext.Orders.ToListAsync();
        }
        //public async Task<Department> GetDepartmentByID(int ID)
        //{
        //    return await _appDBContext.Departments.FindAsync(ID);
        //}
        public async Task<Order> InsertOrder(Order objOrder)
        {
            _appDBContext.Orders.Add(objOrder);
            await _appDBContext.SaveChangesAsync();
            return objOrder;
        }
        public async Task<Order> UpdateOrder(Order objOrder)
        {
            _appDBContext.Entry(objOrder).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objOrder;
        }
        public bool DeleteOrder(int ID)
        {
            bool result = false;
            var order = _appDBContext.Products.Find(ID);
            if (order != null)
            {
                _appDBContext.Entry(order).State = EntityState.Deleted;
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
