using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintTicket.Messaging
{
    public interface ISeasonTicketRequestConsumer
    {
        void Start();
        void Stop();
    }
}
