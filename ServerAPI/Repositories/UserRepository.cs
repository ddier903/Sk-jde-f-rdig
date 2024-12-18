using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Core;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using MongoDB.Driver.Core.Authentication;
namespace ServerAPI.Repositories;



public class UserRepository
{
    private readonly string connectionString = "mongodb+srv://victorot:hvderkmn12345@cluster0.u4phc.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
    private readonly IMongoClient mongoClient;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<User> collection;

    public UserRepository()
    {
        mongoClient = new MongoClient(connectionString);
        database = mongoClient.GetDatabase("Skjøde");
        collection = database.GetCollection<User>("User");
    }

	//Add Admin User
	public async Task PostAdmin(Admin admin)
	{
		admin.Role = "Admin";
		await collection.InsertOneAsync(admin);
	}
    //Add Subcontractor User
    public async Task PostSubcontractor(Subcontractor subcontractor)
    {
        subcontractor.Role = "Subcontractor";
        await collection.InsertOneAsync(subcontractor);
    }

    //Add Tenant User
    public async Task PostTenant(Tenant tenant)
    {
        tenant.Role = "Tenant";
        await collection.InsertOneAsync(tenant);
    }

    //Delete User
    public async Task DeleteUSer(string userId)
	{
		var filter = Builders<User>.Filter.Eq("UserId", userId);
		await collection.DeleteOneAsync(filter);
	}
	//Update User
	public async Task UpdateUser(string userId, User updateduser)
	{
		var filter = Builders<User>.Filter.Eq("UserId", userId);

		var update = Builders<User>.Update
	   .Set(user => user.Phone, updateduser.Phone)
	   .Set(user => user.Email, updateduser.Email);
	 
	}

	//Get User by Username and Password
	public async Task<bool> Authenticate(string username, string password)
	{
		var filter1 = Builders<User>.Filter.Eq("UserName", username);
		var filter2 = Builders<User>.Filter.Eq("Password", password);
		var combinedfilter = Builders<User>.Filter.And(
		filter1,
		filter2
		);

		var user = await collection.Find(combinedfilter).FirstOrDefaultAsync(); ;

        return user != null;
    }

    public async Task<User> GetLoggedInUser(string username)
    {
        var filter1 = Builders<User>.Filter.Eq("UserName", username);

        return await collection.Find(filter1).FirstOrDefaultAsync(); ;
    }
    //Get User by UserID
    public async Task<User> GetUserById(string userId)
	{
		var filter = Builders<User>.Filter.Eq("UserId", userId);
		return await collection.Find(filter).FirstOrDefaultAsync();
	}

	//Get Subcontractors
	public async Task<List<Subcontractor>> GetAllSubcontractors()
	{
		var filter = Builders<User>.Filter.Eq("Role", "Subcontractor");

        var result = await collection.Find(filter).ToListAsync();

        
        return result.OfType<Subcontractor>().ToList();
    }
}