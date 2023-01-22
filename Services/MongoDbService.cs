using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoExample.Services;

public class MongoDbService {
    private readonly IMongoCollection<Product> _productsCollection;

    public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings) {
        MongoClient client = new MongoClient(mongoDbSettings.Value.ConnectionURL);
        IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _productsCollection = database.GetCollection<Product>(mongoDbSettings.Value.CollectionName);
    }

    public async Task CreateProduct(Product product) {
        await _productsCollection.InsertOneAsync(product);
        return;
    }

    public async Task<List<Product>> GetProducts() {
        return await _productsCollection.Find(new BsonDocument()).ToListAsync();
    }

}
