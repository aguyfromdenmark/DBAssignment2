using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDatabase<T>
    {
        T GetByPhone(string phoneNumber);
        void Create(T item);
        void Update(T item);
        void Delete(string itemId);
    }
}
