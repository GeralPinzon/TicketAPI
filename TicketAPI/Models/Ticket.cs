using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TicketAPI.Models
{
    public class Ticket
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Usuario { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime Dateupdate { get; set; }
        public string State { get; set; }
    }
}
