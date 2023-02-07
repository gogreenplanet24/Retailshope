using Retailshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retailshop.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrder();
        //Task<Department> GetDepartmentByID(int ID);
        Task<Order> InsertOrder(Order objOrder);
        Task<Order> UpdateOrder(Order objOrder);
        bool DeleteOrder(int ID);
    }
}
