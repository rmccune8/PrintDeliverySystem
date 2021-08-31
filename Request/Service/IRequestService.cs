using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Service
{
    public interface IRequestService
    {
        Task ProcessSeasonTicketRequestAsync(Guid clientId, int year);
    }
}
