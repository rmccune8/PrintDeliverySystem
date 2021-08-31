using MessagingBus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingBus.Service
{
    public interface IMessageBus
    {
        Task PublishMessageAsync(BaseMessage message, string topic);
        Task PublishMessageBulkAsync(IEnumerable<BaseMessage> messages, string topic);
    }
}
