using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Request.Model;

namespace Request.Repository
{
    public class RequestRepository : IRequestRepository
    {
        public async Task<List<Patron>> GetPatrons(Guid clientId, int year)
        {
            // this should query database & retrieve patrons for this client
            return new List<Patron>();
        }
    }
}
