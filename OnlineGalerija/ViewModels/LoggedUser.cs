using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.ViewModels
{
    public class MongoUser
    {
        public string objId { get; set; }
        public Models.User mongoUser { get; set; }
    }
    public class PostgreUser
    {
        public int userId { get; set; }
        public PostgresModels.User postgreUser { get; set; }
    }
    public class LoggedUser
    {
        public MongoUser mongoUser { get; set; } = null;
        public PostgreUser postgreUser { get; set; } = null;
        public bool IsMongoUser { get; set; }
    }
}
