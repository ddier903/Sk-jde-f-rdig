using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServerAPI.Repositories;
public class ApartmentRepository
{
    private readonly string connectionString = "mongodb+srv://victorot:hvderkmn12345@cluster0.u4phc.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
    private readonly IMongoClient mongoClient;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<Apartments> collection;

    public ApartmentRepository()
    {
        mongoClient = new MongoClient(connectionString);
        database = mongoClient.GetDatabase("Skjøde");
        //collection = database.GetCollection<Apartments>("Apartments");
    }
}