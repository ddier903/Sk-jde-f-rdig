﻿using MongoDB.Driver;
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
        //collection = database.GetCollection<Apartments>("Apartments");
    }

    //Post apartment: 

    //Update apartment: 

    //Get all Apartments:

    // Get all apartments filtered by status:

    //Get Apartment:

    //Get Apartments "Ikke færdig" Count. 
}