using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL : IDatabase<CustomerModel>
    {
        public void Create(CustomerModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string itemId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetSingle(string itemId)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerModel item)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetByPhone(string phoneNuber)
        {
            throw new NotImplementedException();
        }
    }
}
