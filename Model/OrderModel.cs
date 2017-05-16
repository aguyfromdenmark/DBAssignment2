using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderModel
    {
        public string Id { get; set; }
        public DateTime DatePlaces { get; set; }
        public List<OrderLineModel> Lines { get; set; }
        public int TotalPrice { get; set; }

        public OrderModel()
        {
            Lines = new List<OrderLineModel>();    
        }
    }
}
