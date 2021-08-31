using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintTicket.Model
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public SportingEvent SportingEvent { get; set; }
    }
}
