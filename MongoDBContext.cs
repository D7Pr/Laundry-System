using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laundry_System
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");

        public async Task<Customer> FindCustomerByPhoneNumberAsync(string phoneNumber)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.PhoneNumber, phoneNumber);
            return await Customers.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> FindOrdersByCustomerIdAsync(string customerId)
        {
            var filter = Builders<Order>.Filter.Eq("CustomerId", customerId);
            return await Orders.Find(filter).ToListAsync();
        }
    }
}