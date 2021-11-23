using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public interface ITicketCollection
    {
        Task CreateTicket(Ticket ticket);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(String Id);

        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketById(String id);

    }
}
