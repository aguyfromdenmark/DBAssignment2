using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;

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
            var itemAsBson = itemAsJson.ToBsonDocument();
            collection.InsertOne(itemAsBson);
        }

        public void Delete(string itemId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", itemId);
            collection.DeleteOne(filter);
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
