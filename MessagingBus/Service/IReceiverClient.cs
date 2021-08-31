using MessagingBus.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingBus.Service
{
    public interface IReceiverClient
    {
        void RegisterMessageHandler(Func<BaseMessage, CancellationToken, Task> handler);
    }
}
