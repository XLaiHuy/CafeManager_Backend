using CafeManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAL
{
    public class CustomerDAL
    {
        private readonly CafeContext _context;
        public CustomerDAL(CafeContext context)
        {
            _context = context;
        }
        public Customer getCustomerByID(int id)
        {
            return _context.Customers.FirstOrDefault(c=> c.Id == id && (c.Isdeleted == null || c.Isdeleted == false));
        }
        public Customer getCustomerByPhone(string phone) //tim chinh xac
        {
            return _context.Customers.FirstOrDefault(c => c.Phone == phone && (c.Isdeleted == null || c.Isdeleted == false));
        }
        public List<Customer> SearchCustomer(string phoneKeyword)
        {
            return _context.Customers
                .Where(c => c.Phone.Contains(phoneKeyword) && (c.Isdeleted == null || c.Isdeleted == false))
                .ToList();
        }
        public Customer addCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Where(c => c.Isdeleted == false).ToList();
        }
    }
}
