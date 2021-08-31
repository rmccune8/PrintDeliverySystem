using Request.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Repository
{
    public interface IRequestRepository
    {
        Task<List<Patron>> GetPatrons(Guid clientId, int year);
    }
}
