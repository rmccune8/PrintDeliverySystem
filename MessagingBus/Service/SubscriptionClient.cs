using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MessagingBus.Model;

namespace MessagingBus.Service
{
    public class SubscriptionClient : IReceiverClient
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _topic;
        private readonly string _subscriptionName;
        public SubscriptionClient(string serviceBusConnectionString, string topic, string subscriptionName)
        {
            _serviceBusConnectionString = serviceBusConnectionString;
            _topic = topic;
            _subscriptionName = subscriptionName;
        }

        public void RegisterMessageHandler(Func<BaseMessage, CancellationToken, Task> handler)
        {
            throw new NotImplementedException();
        }
    }
}
