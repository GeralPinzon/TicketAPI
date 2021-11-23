using Microsoft.AspNetCore.Mvc;
using TicketAPI.Models;
using TicketAPI.Repositories;
using TicketAPI.Controllers;
using MongoDB.Driver;

namespace TicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
 
        //private ITicketCollection db = new TicketCollection();
        private ITicketCollection db = new TicketCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {

            return Ok(await db.GetAllTickets());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketDetails(string id)
        {
            return Ok(await db.GetTicketById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            if (ticket.Usuario == string.Empty)
            {
                ModelState.AddModelError("Name", "The user shouldn't be empty ");
            }
            await db.CreateTicket(ticket);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UptdateTicket([FromBody] Ticket ticket, string id)
        {

            if (ticket == null)
            {
                return BadRequest();
            }
            if (ticket.Usuario == string.Empty)
            {
                ModelState.AddModelError("Name", "The user shouldn't be empty ");
            }

            ticket.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateTicket(ticket);
            return Created("Created", true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(string id)
        {
            await db.DeleteTicket(id);
            return NoContent(); //Exit
        }
    }
}
