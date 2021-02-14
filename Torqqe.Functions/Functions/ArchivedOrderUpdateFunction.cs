using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Torqqe.Data;
using Torqqe.Functions.Business;
using Torqqe.ShopmonkeyApi;

namespace Torqqe.Functions.Functions
{
    public  class ArchivedOrderUpdateFunction
    {
        private readonly ShopmonkeyClient _client;
        private readonly IMapper _mapper;
        private readonly TorqqeContext _context;
        private MasterDataCopy _masterDataCopy;

        public ArchivedOrderUpdateFunction(ShopmonkeyClient client, IMapper mapper, TorqqeContext context)
        {
            _client = client;
            _mapper = mapper;
            _context = context;
        }

        [Disable]
        [FunctionName("archived-order-update-function")]
        public async Task Run([TimerTrigger("%ArchivedOrderInterval%")] TimerInfo myTimer, ILogger log)
        //public async Task Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)

        {
            log.LogInformation($"{DateTime.Now}: Order update trigger function processed a request.");

            _masterDataCopy = new MasterDataCopy(_client, _mapper, _context, log);

            try
            {
                log.LogInformation("Order update is starting.");
                await _masterDataCopy.OrderDataCopy(true);

                _masterDataCopy.ClearDuplicatedOrder();
            }
            catch (System.Exception ex)
            {
                log.LogError(ex.ToString());
                throw;
            }
        }
    }
}
