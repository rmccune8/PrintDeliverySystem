using MessagingBus.Model;
using MessagingBus.Service;
using Notification.Messages;
using Notification.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Messaging
{
    public class NotificationConsumer : INotificationConsumer
    {
        private readonly IConfigProvider _configProvider;
        private readonly IMessageBus _messageBus;
        private readonly IS3Client _s3Client;
        private readonly INotificationSender _notificationSender;

        private readonly string _seasonTicketRequestCompleteTopic;
        private readonly string _subscriptionName = "PrintDeliverySystemRequest";

        private readonly IReceiverClient _seasonTicketRequestReceiverClient;
        public NotificationConsumer(IConfigProvider configProvider, IMessageBus messageBus, IS3Client s3Client, INotificationSender notificationSender)
        {
            _configProvider = configProvider;
            _messageBus = messageBus;
            _s3Client = s3Client;
            _notificationSender = notificationSender;

            string serviceBusConnString = _configProvider.GetValue<string>("ServiceBusConnectionString");
            _seasonTicketRequestCompleteTopic = _configProvider.GetValue<string>("SeasonTicketRequestCompleteTopic");
            _seasonTicketRequestReceiverClient = new SubscriptionClient(serviceBusConnString, _seasonTicketRequestCompleteTopic, _subscriptionName);
        }

        public void Start()
        {
            // register message handlers
            _seasonTicketRequestReceiverClient.RegisterMessageHandler(OnSeasonTicketRequestCompleteReceived);
        }

        private async Task OnSeasonTicketRequestCompleteReceived(BaseMessage message, CancellationToken cancellationToken)
        {
            NotificationMessage notificationMessage = (NotificationMessage)message;
            // get from s3 by clientId


            // aggregate/zip 

            // send via sms/email
            string messageBody = GetMessageBody();
            await _notificationSender.SendAsync(messageBody);

            // if error, retry with exponential backoff

            // if still no success, send to error queue

            // log success/failures

            // have service that knows how to process errored queue items
        }

        private string GetMessageBody()
        {
            // get message body
        }

        public void Stop()
        {
            
        }
    }
}
