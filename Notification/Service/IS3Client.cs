using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Service
{
    public interface IS3Client
    {
        Task<byte[]> GetFromS3(Guid id);
    }
}
