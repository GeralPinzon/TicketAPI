using MongoDB.Bson;
using MongoDB.Driver;
using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public class TicketCollection : ITicketCollection
    {
        //dddd
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Ticket> Collection;

        public TicketCollection()
        {
            Collection = _repository.db.GetCollection<Ticket>("Tickets");
        }
        public async Task CreateTicket(Ticket ticket)
        {
            await Collection.InsertOneAsync(ticket);
        }
        public async Task DeleteTicket(string id)
        {
            var filter = Builders<Ticket>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Ticket>> GetAllTickets()
        {

            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
        public async Task<Ticket> GetTicketById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            var filter = Builders<Ticket>.Filter.Eq(s => s.Id, ticket.Id);
            await Collection.ReplaceOneAsync(filter, ticket);
        }

    }
}
