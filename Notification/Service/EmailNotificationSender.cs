using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Service
{
    public class EmailNotificationSender : INotificationSender
    {
        public async Task SendAsync(string messageBody)
        {
            // send via email
        }
    }
}
