using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.Models
{
    public class mongoDbContext
    {
        public MongoClient client;
        public IMongoDatabase database;
        public mongoDbContext()
        {
            client = new MongoClient("mongodb+srv://mrakks:MyWeakPassword@cluster0.rdvtp.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            database = client.GetDatabase("testbaza");
        }
        

    }
}
