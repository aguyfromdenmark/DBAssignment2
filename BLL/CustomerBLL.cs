using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class CustomerBLL
    {
        private CustomerDAL _customerDAL = new CustomerDAL();

        public CustomerBLL()
        {
        }

        public CustomerModel GetCustomerByPhone(string phoneNumber)
        {
            return _customerDAL.GetByPhone(phoneNumber);
        }

        public void CreateCustomer(CustomerModel customer)
        {
            _customerDAL.Create(customer);
        }

        public void DeleteCustomer(string customerId)
        {
            _customerDAL.Delete(customerId);
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            _customerDAL.Update(customer);
        }
    }
}
