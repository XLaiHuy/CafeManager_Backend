using CafeManager.DAL;
using CafeManager.DAL.Models;
using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.BUS
{
    public class CustomerBUS
    {
        private readonly CustomerDAL _customerDal;
        public CustomerBUS(CustomerDAL customerDal)
        {
            _customerDal = customerDal;
        }
        public List<CustomerDTO> GetAllCustomers()
        {
            return _customerDal.GetAllCustomers().Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
              
            }).ToList();
        }
        public List<CustomerDTO> SearchCustomer(string phone)
        {
            return _customerDal.SearchCustomer(phone).Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
            }).ToList();
        }
        public CustomerDTO CreateCustomer(CustomerDTO input)
        {
            // Check trùng SĐT
            if (!string.IsNullOrWhiteSpace(input.Phone) && input.Phone != "string")
            {
                var existing = _customerDal.getCustomerByPhone(input.Phone);
                if (existing != null)
                {
                    throw new Exception("Số điện thoại này đã tồn tại!");
                }
            }

            var customer = new Customer
            {
                Name = input.Name,
                Phone = input.Phone,
                Id= input.Id,
                Isdeleted = false
            };
            var newCustomer = _customerDal.addCustomer(customer);
            return new CustomerDTO
            {
                Id = newCustomer.Id, // Đã có ID thật từ DB
                Name = newCustomer.Name,
                Phone = newCustomer.Phone,
            };
        }
    }
}
