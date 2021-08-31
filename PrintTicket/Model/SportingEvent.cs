using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintTicket.Model
{
    public class SportingEvent
    {
        public Guid Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDateTime { get; set; }
    }
}
