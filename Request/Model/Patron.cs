using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Model
{
    public class Patron
    {
        public Guid Id { get; set; }
        public List<SportingEvent> SportingEvents { get; set; }
    }
}
