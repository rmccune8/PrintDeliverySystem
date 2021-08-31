using PrintTicket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintTicket.Repository
{
    public interface IPrintTicketRepository
    {
        Task<List<SportingEvent>> GetTickets(Guid patronId);
    }
}
