using AutoMapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Torqqe.Data;
using Torqqe.Functions.Business;
using Torqqe.ShopmonkeyApi;

namespace Torqqe.Functions.Functions
{
    public class DailySyncFunction
    {
        private readonly ShopmonkeyClient _client;
        private readonly IMapper _mapper;
        private readonly TorqqeContext _context;
        private MasterDataCopy _masterDataCopy;
        public DailySyncFunction(ShopmonkeyClient client, IMapper mapper, TorqqeContext context)
        {
            _client = client;
            _mapper = mapper;
            _context = context;
        }

        [FunctionName("daily-sync-function")]
        public async Task Run([TimerTrigger("%DailyInterval%")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"{DateTime.Now}: Daily update trigger function processed a request.");

            _masterDataCopy = new MasterDataCopy(_client, _mapper, _context, log);

            try
            {
                //Master Data Copy
                log.LogInformation("Customer update is starting.");
                _masterDataCopy.CustomerDataCopy();

                log.LogInformation("Vehicle update is starting.");
                _masterDataCopy.VehicleDataCopy();

                //Archived Order Copy
                log.LogInformation("Archived Order update is starting.");
                await _masterDataCopy.OrderDataCopy(true);

                //Nonarch Order Copy
                log.LogInformation("Order update is starting.");
                await _masterDataCopy.OrderDataCopy(false);
                
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
