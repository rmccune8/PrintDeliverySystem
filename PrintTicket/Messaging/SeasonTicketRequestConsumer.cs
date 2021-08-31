using MessagingBus.Model;
using MessagingBus.Service;
using PrintTicket.Messages;
using PrintTicket.Repository;
using PrintTicket.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrintTicket.Messaging
{
    public class SeasonTicketRequestConsumer : ISeasonTicketRequestConsumer
    {
        private readonly IConfigProvider _configProvider;
        private readonly IMessageBus _messageBus;
        private readonly IPrintTicketRepository _printTicketRepository;

        private readonly string _seasonTicketRequestTopic;
        private readonly string _subscriptionName = "PrintDeliverySystemRequest";

        private readonly IReceiverClient _seasonTicketRequestReceiverClient;

        public SeasonTicketRequestConsumer(IConfigProvider configProvider, IMessageBus messageBus, IPrintTicketRepository printTicketRepository)
        {
            _configProvider = configProvider;
            _messageBus = messageBus;
            _printTicketRepository = printTicketRepository;

            string serviceBusConnString = _configProvider.GetValue<string>("ServiceBusConnectionString");
            _seasonTicketRequestTopic = _configProvider.GetValue<string>("SeasonTicketRequestTopic");
            _seasonTicketRequestReceiverClient = new SubscriptionClient(serviceBusConnString, _seasonTicketRequestTopic, _subscriptionName);
        }

        public void Start()
        {
            // register message handlers
            _seasonTicketRequestReceiverClient.RegisterMessageHandler(OnSeasonTicketRequestReceived);
        }

        private async Task OnSeasonTicketRequestReceived(BaseMessage message, CancellationToken cancellationToken)
        {
            // there will be 1 message per patron
            SeasonTicketRequestMessage seasonTicketRequestMessage = (SeasonTicketRequestMessage)message;
            // get tickets for patron
            var sportingEvents = await _printTicketRepository.GetTickets(seasonTicketRequestMessage.PatronId);
            // process & store in S3. external service called to place barcode on tickets? If so, need to consider sending request to external resource in bulk


            // when all completed for a client, fire event that NotificationService will pick up


            // if error, retry with exponential backoff

            // if still no success, send to error queue

            // have service that knows how to process errored queue items

        }

        public void Stop()
        {
            
        }
    }
}
