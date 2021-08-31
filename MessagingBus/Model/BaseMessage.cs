using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingBus.Model
{
    public class BaseMessage
    {
        public Guid Id { get; set; }
        public DateTime MessageDateTime { get; set; }
    }
}
