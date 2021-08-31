using MessagingBus.Service;
using Request.Messages;
using Request.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.Service
{
    public class RequestService : IRequestService
    {
        private readonly ILogger _logger;
        private readonly IMessageBus _messageBus;
        private readonly IRequestRepository _requestRepository;
        public RequestService(ILogger logger, IMessageBus messageBus, IRequestRepository requestRepository)
        {
            _logger = logger;
            _messageBus = messageBus;
            _requestRepository = requestRepository;
        }

        public async Task ProcessSeasonTicketRequestAsync(Guid clientId, int year)
        {
            if (clientId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(clientId)} can't be all zeros");
            }

            await _logger.InfoAsync($"Starting season ticket request for {clientId}, year {year}");

            // query repo and break up by patron
            var patrons = await _requestRepository.GetPatrons(clientId, year);
            List<SeasonTicketRequestMessage> seasonTicketRequestMessages = new List<SeasonTicketRequestMessage>();
            foreach (var patron in patrons)
            {
                SeasonTicketRequestMessage seasonTicketRequestMessage = new SeasonTicketRequestMessage()
                {
                    Id = clientId,
                    MessageDateTime = DateTime.UtcNow,
                    Year = year,
                    PatronId = patron.Id
                };
                seasonTicketRequestMessages.Add(seasonTicketRequestMessage);
            }
            // publish in bulk
            await _messageBus.PublishMessageBulkAsync(seasonTicketRequestMessages, "SeasonTicketRequestMessage");

            await _logger.InfoAsync($"Season ticket request message published for {clientId}, year {year}");
        }
    }
}
