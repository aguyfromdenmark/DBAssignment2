using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;

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
            var items = collection.Find(new BsonDocument()).ToList();
            var returnList = new List<CustomerModel>();

            foreach (var document in items)
            {
                returnList.Add(JsonConvert.DeserializeObject<CustomerModel>(document.ToJson()));
            }

            return returnList;
        }

        public CustomerModel GetSingle(string itemId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", itemId);
            var item = collection.Find(filter);
            return JsonConvert.DeserializeObject<CustomerModel>(item.ToJson());
        }

        public void Update(CustomerModel item)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetByPhone(string phoneNumber)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("PhoneNumber", phoneNumber);
            var item = collection.Find(filter);
            return JsonConvert.DeserializeObject<CustomerModel>(item.ToJson());
        }
    }
}
