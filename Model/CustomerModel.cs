﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerModel
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int PhoneNumber  { get; set; }
        public string Email { get; set; }
        public List<OrderModel> Orders { get; set; }

        public CustomerModel()
        {
            Id = ObjectId.GenerateNewId();
            Orders = new List<OrderModel>();   
        }

        public void CreateIdFromString(string id)
        {
            if (id != null)
            {
                this.Id = ObjectId.Parse(id);
            }
        }
    }
}
