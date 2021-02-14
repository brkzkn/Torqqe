using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class OrderManuelUpdate
    {
        private readonly ShopmonkeyClient _client;
        private readonly IMapper _mapper;
        private readonly TorqqeContext _context;
        private MasterDataCopy _masterDataCopy;

        public OrderManuelUpdate(ShopmonkeyClient client, IMapper mapper, TorqqeContext context)
        {
            _client = client;
            _mapper = mapper;
            _context = context;
        }

        [FunctionName("shopmonkey-order-sync")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            _masterDataCopy = new MasterDataCopy(_client, _mapper, _context, log);

            log.LogInformation($"{DateTime.Now}: Shopmonkey order update trigger function processed a request.");

            bool.TryParse(req.Query["isArchived"], out bool isArchived);
            string[] orderIds = req.Query["orderIDs"].ToString().Split(",", StringSplitOptions.RemoveEmptyEntries);

            if (orderIds.Length > 0)
            {
                foreach (var orderId in orderIds)
                {
                    if (int.TryParse(orderId, out int orderNumber))
                        await _masterDataCopy.OrderDataCopy(isArchived, orderNumber: orderNumber);
                }
            }
            else
            {
                await _masterDataCopy.OrderDataCopy(isArchived);
            }
            return new OkResult();
        }
    }
}
