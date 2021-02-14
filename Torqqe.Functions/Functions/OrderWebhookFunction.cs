using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Torqqe.Functions.Model;
using System.Collections.Generic;
using Torqqe.ShopmonkeyApi;
using AutoMapper;
using Torqqe.Data;
using Torqqe.Functions.Business;

namespace Torqqe.Functions.Functions
{
    public class OrderWebhookFunction
    {
        private readonly ShopmonkeyClient _client;
        private readonly IMapper _mapper;
        private readonly TorqqeContext _context;
        private MasterDataCopy _masterDataCopy;

        public OrderWebhookFunction(ShopmonkeyClient client, IMapper mapper, TorqqeContext context)
        {
            _client = client;
            _mapper = mapper;
            _context = context;
        }

        [FunctionName("order-webhook-function")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            _masterDataCopy = new MasterDataCopy(_client, _mapper, _context, log);
            
            log.LogInformation($"{DateTime.Now}: Order update webhook trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<IList<OrderWebhookModel>>(requestBody);
            log.LogInformation($"Body\r\n: {requestBody}");
            foreach (var item in data)
            {
                await _masterDataCopy.OrderDataCopy(item.Data.IsArchived, item.Data.JobNumber);
            }

            _masterDataCopy.ClearDuplicatedOrder();

            return new OkResult();
        }
    }
}
