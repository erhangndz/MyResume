using EntityLayer.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntityLayer.Entities
{
    public class Education : IMongoEntity
    {
       

        public string SchoolName { get; set; }
        public string Department { get; set; }
        public int StartYear { get; set; }
        public int FinishYear { get; set; }
    }
}
