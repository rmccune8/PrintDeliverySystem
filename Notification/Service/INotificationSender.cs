using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Service
{
    public interface INotificationSender
    {
        Task SendAsync(string messageBody);
    }
}
