using MessagingBus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintTicket.Messages
{
    public class SeasonTicketRequestMessage : BaseMessage
    {
        public int Year { get; set; }
        public Guid PatronId { get; set; }
    }
}
