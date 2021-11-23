using TicketAPI.Models;

namespace TicketAPI.Controllers
{
    public interface IProductController
    {
        Task<object?> GetTicketById(string id);
        Task InsertTicket(Ticket ticket);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(string id);
        Task<object?> GetAllProducts();
    }
}