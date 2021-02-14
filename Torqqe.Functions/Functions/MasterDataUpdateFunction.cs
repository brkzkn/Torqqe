using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using Torqqe.Data;
using Torqqe.Functions.Business;
using Torqqe.ShopmonkeyApi;

namespace Torqqe.Functions.Functions
{
    public class MasterDataUpdateFunction
    {
        private readonly ShopmonkeyClient _client;
        private readonly IMapper _mapper;
        private readonly TorqqeContext _context;
        private MasterDataCopy _masterDataCopy;
        public MasterDataUpdateFunction(ShopmonkeyClient client, IMapper mapper, TorqqeContext context)
        {
            _client = client;
            _mapper = mapper;
            _context = context;
        }

        [Disable]
        [FunctionName("masterdata-update-function")]
        public void Run([TimerTrigger("%MasterDataInterval%")]TimerInfo myTimer, ILogger log)
        //public void Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation($"{DateTime.Now}: MasterData update trigger function processed a request. ");

            _masterDataCopy = new MasterDataCopy(_client, _mapper, _context, log);

            try
            {
                log.LogInformation("Customer update is starting.");
                _masterDataCopy.CustomerDataCopy();

                log.LogInformation("Vehicle update is starting.");
                _masterDataCopy.VehicleDataCopy();

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
