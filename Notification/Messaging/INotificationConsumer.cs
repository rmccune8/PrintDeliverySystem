using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Messaging
{
    public interface INotificationConsumer
    {
        void Start();
        void Stop();
    }
}
