using MongoDB.Driver;
using AcaiStoreApi.Models;
using Microsoft.Extensions.Options;

namespace AcaiStoreApi.Services;

public class AcaisService
{
    private readonly IMongoCollection<Acai> _acaisCollection;

    public AcaisService(
        IOptions<AcaiStoreDatabaseSettings> acaiStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            acaiStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            acaiStoreDatabaseSettings.Value.DatabaseName);

        _acaisCollection = mongoDatabase.GetCollection<Acai>(
            acaiStoreDatabaseSettings.Value.AcaisCollectionName);
    }

    public async Task<List<Acai>> GetAsync() =>
        await _acaisCollection.Find(_ => true).ToListAsync();

    public async Task<Acai?> GetAsync(string id) =>
        await _acaisCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Acai newAcai) =>
        await _acaisCollection.InsertOneAsync(newAcai);

    public async Task UpdateAsync(string id, Acai updatedBook) =>
        await _acaisCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _acaisCollection.DeleteOneAsync(x => x.Id == id);
}