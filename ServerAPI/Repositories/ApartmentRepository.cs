using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Core; 

namespace ServerAPI.Repositories;
public class ApartmentRepository
{
    private readonly string connectionString = "mongodb+srv://victorot:hvderkmn12345@cluster0.u4phc.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
    private readonly IMongoClient mongoClient;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<Apartment> collection;

    public ApartmentRepository()
    {
        mongoClient = new MongoClient(connectionString);
        database = mongoClient.GetDatabase("Skjøde");
        collection = database.GetCollection<Apartment>("Apartments");
    }

    //Post apartment: 
    public async Task PostApartment(Apartment apartment)
    {
        var existingapartment = await collection.Find(a => a.Address == apartment.Address).FirstOrDefaultAsync();

        if (existingapartment != null)
        {
            throw new InvalidOperationException($"An apartment with address '{apartment.Address}' already exists.");
        }

        await collection.InsertOneAsync(apartment);
    }
    //Update apartment: 
    public async Task UpdateApartment(string id, Apartment updatedApartment)
    {
        var filter = Builders<Apartment>.Filter.Eq(a => a.ApartmentId, id);
        await collection.ReplaceOneAsync(filter, updatedApartment);
    }

    //Get all Apartments:
    public async Task<List<Apartment>> GetAllApartments()
    {
        return await collection.Find(apartment => true).ToListAsync();
    }


    // Get all apartments filtered by status:
    public async Task<List<Apartment>> GetApartmentsByStatus(string status)
    {
        var filter = Builders<Apartment>.Filter.Eq(a => a.Status, status);
        return await collection.Find(filter).ToListAsync();
    }

    //Get Apartment:
    public async Task<Apartment> GetApartment(string apartmentId)
    {
        var filter = Builders<Apartment>.Filter.Eq(a => a.ApartmentId, apartmentId);
        return await collection.Find(filter).FirstOrDefaultAsync();
    }


    //Get Apartments "Ikke færdig" Count. 
    public async Task<long> GetApartmentsNotFinishedCount()
    {
        var filter = Builders<Apartment>.Filter.Eq(a => a.Status, "Ikke færdig");
        return await collection.CountDocumentsAsync(filter);
    }

}