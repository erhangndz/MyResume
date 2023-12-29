using EntityLayer.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntityLayer.Entities
{
    public class Testimonial: IMongoEntity
    {
       

        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }

        public string Comment { get; set; }


    }
}
