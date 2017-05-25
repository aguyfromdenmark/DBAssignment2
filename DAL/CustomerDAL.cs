﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization;

namespace DAL
{
    public class CustomerDAL : IDatabase<CustomerModel>
    {
        private IMongoClient mongoClient;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;

        public CustomerDAL()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
            database = mongoClient.GetDatabase("CustomerInfoDb");
            collection = database.GetCollection<BsonDocument>("Customers");
        }
        public void Create(CustomerModel item)
        {
            var itemAsJson = item.ToJson();
            var itemAsBson = BsonSerializer.Deserialize<BsonDocument>(itemAsJson);
            collection.InsertOne(itemAsBson);
        }
        public CustomerModel GetByPhone(string phoneNumber)
        {
            int phoneNumberAsInt = Int32.Parse(phoneNumber);

            var filter = Builders<BsonDocument>.Filter.Eq("PhoneNumber", phoneNumberAsInt);

            var item = collection.Find(filter).FirstOrDefault();

            return BsonSerializer.Deserialize<CustomerModel>(item.AsBsonDocument);
        }

        public void Delete(string itemId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", itemId);
            collection.DeleteOne(filter);
        }

        public void Update(CustomerModel item)
        {
            throw new NotImplementedException();
        }
    }
}
