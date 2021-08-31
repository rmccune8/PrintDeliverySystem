using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Service
{
    public interface ILogger
    {
        Task ErrorAsync(string message);
        Task InfoAsync(string message);
    }
}
