using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Model
{
    public class SeasonTicketRequest
    {
        public Guid ClientId { get; set; }
        public int Year { get; set; }
    }
}
