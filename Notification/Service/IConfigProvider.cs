using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Service
{
    public interface IConfigProvider
    {
        T GetValue<T>(string key);
    }
}
