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


    public async Task<Apartment> GetApartmentByUserId(string userId)
    {
        
        var filter = Builders<Apartment>.Filter.Eq(a => a.Tenant.UserId, userId);

       
        return await collection.Find(filter).FirstOrDefaultAsync();
    }


    public async Task<bool> AssignTenantToApartment(string apartmentId, Tenant tenant)
    {
        var filter = Builders<Apartment>.Filter.Eq(a => a.ApartmentId, apartmentId);
        var update = Builders<Apartment>.Update.Set(a => a.Tenant, tenant);
        var result = await collection.UpdateOneAsync(filter, update);

        return result.ModifiedCount > 0; // Return true if a document was modified
    }
    // Add Availability to an Apartment
    public async Task<bool> UpdateApartmentAvailability(string apartmentId, List<Availability> availabilities)
    {
        
        foreach (var availability in availabilities)
        {
            availability.Date = availability.Date.ToUniversalTime();
        }


        var filter = Builders<Apartment>.Filter.Eq(a => a.ApartmentId, apartmentId);
        var update = Builders<Apartment>.Update.Set(a => a.Availability, availabilities);
        var result = await collection.UpdateOneAsync(filter, update);

        return result.ModifiedCount > 0;
    }


    // Get All Availabilities for an Apartment
    public async Task<List<Availability>> GetAvailabilitiesByApartmentId(string apartmentId)
    {
        var filter = Builders<Apartment>.Filter.Eq(a => a.ApartmentId, apartmentId);
        var apartment = await collection.Find(filter).FirstOrDefaultAsync();

        if (apartment?.Availability != null)
        {
            foreach (var availability in apartment.Availability)
            {
                availability.Date = availability.Date.ToLocalTime();

            }
        }

        return apartment?.Availability ?? new List<Availability>();
    }


}