using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class CustomerBLL
    {
        private CustomerDAL _customerDAL;

        public CustomerBLL()
        {
            _customerDAL = new CustomerDAL();
        }

        public CustomerModel GetCustomerById(string id)
        {
            return _customerDAL.GetSingle(id);
        }

        public CustomerModel GetCustomerByPhone(string phoneNumber)
        {
            return _customerDAL.GetByPhone(phoneNumber);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _customerDAL.GetAll();
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
