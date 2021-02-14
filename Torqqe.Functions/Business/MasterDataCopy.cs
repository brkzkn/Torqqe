using AutoMapper;
using AutoMapper.Internal;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoreLinq;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Torqqe.Data;
using Torqqe.Data.Models;
using Torqqe.ShopmonkeyApi;

namespace Torqqe.Functions.Business
{
    public class MasterDataCopy
    {
        private readonly ShopmonkeyClient _client;
        private readonly IMapper _mapper;
        private readonly TorqqeContext _context;
        private readonly ILogger _logger;
        public MasterDataCopy(ShopmonkeyClient client, IMapper mapper, TorqqeContext context, ILogger logger)
        {
            _client = client;
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public void CustomerDataCopy()
        {
            int offset = 0;
            List<Customer> customers = new List<Customer>();
            List<Email> emails = new List<Email>();
            List<Phone> phones = new List<Phone>();

            _logger.LogInformation("Get existing phones and emails of customer");
            var existingEmails = _context.Emails.ToList();
            var existingPhones = _context.Phones.ToList();

            do
            {
                _logger.LogInformation("Get customers from shopmonkey...");
                var result = _client.GetCustomers(offset: offset, limit: 500);
                if (result == null || result.Count == 0)
                    break;

                _logger.LogInformation($"Fetched {result.Count} customers from shopmonkey...");
                var customerTemp = _mapper.Map<List<Customer>>(result);
                customers.AddRange(customerTemp);

                _logger.LogInformation($"Emails and phones are preparing...");
                foreach (var customer in customerTemp.Where(x => x.Emails.Count > 0))
                {
                    foreach (var email in customer.Emails)
                    {
                        var existingId = existingEmails.FirstOrDefault(x => x.CustomerShopmonkeyId == customer.ShopmonkeyId
                                                                         && x.EmailAddress == email.EmailAddress)?.Id;

                        emails.Add(new Email()
                        {
                            EmailAddress = email.EmailAddress,
                            CustomerShopmonkeyId = customer.ShopmonkeyId,
                            Id = existingId ?? 0
                        });
                    }
                }

                foreach (var customer in customers.Where(x => x.Phones.Count > 0))
                {
                    phones.AddRange(customer.Phones);
                }

                offset += result.Count;

            } while (true);

            _logger.LogInformation("Bulk upsert is starting...");

            var policy = Policy.Handle<Exception>()
                               .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                _context.BulkInsertOrUpdate<Customer>(customers);
                _context.BulkInsertOrUpdate<Email>(emails);
                _context.BulkInsertOrUpdate<Phone>(phones);

                UpdateTableInfo(new string[] { nameof(Customer), nameof(Email), nameof(Phone) });
            });

            _logger.LogInformation("Bulk upsert completed...");
        }

        public void VehicleDataCopy()
        {
            int offset = 0;
            var vehicles = new List<Vehicle>();
            var vehicleOwners = new List<VehicleOwner>();

            do
            {
                _logger.LogInformation("Get vehicles from shopmonkey...");
                var result = _client.GetVehicle(offset: offset, limit: 500);
                if (result == null || result.Count == 0)
                    break;

                _logger.LogInformation($"Fetched {result.Count} vehicles from shopmonkey...");
                var vehicleTemp = _mapper.Map<List<Vehicle>>(result);
                vehicles.AddRange(vehicleTemp);

                foreach (var vehicle in vehicleTemp.Where(x => x.VehicleOwners.Count > 0))
                {
                    vehicleOwners.AddRange(vehicle.VehicleOwners);
                }

                offset += result.Count;

            } while (true);

            _logger.LogInformation("Bulk upsert is starting...");
            var policy = Policy.Handle<Exception>()
                               .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                _context.BulkInsertOrUpdate<Vehicle>(vehicles);
                _context.BulkInsertOrUpdate<VehicleOwner>(vehicleOwners);
                UpdateTableInfo(new string[] { nameof(VehicleOwner), nameof(Vehicle) });
            });

            _logger.LogInformation("Bulk upsert completed...");
        }

        public async Task OrderDataCopy(bool isArchived = false, int? orderNumber = null)
        {
            int offset = 0;
            var jobList = new List<Job>();
            var parts = new List<Part>();
            var subcontracts = new List<Subcontract>();
            var labors = new List<Labor>();
            var totals = new List<Total>();
            var orders = new List<Order>();
            var vehicles = new List<Vehicle>();
            var customers = new List<Customer>();

            _logger.LogInformation("Getting existing customers and vehicles");
            var existingCustomerIDs = _context.Customers.Select(c => c.ShopmonkeyId).ToList();
            var existingVehicleIDs = _context.Vehicles.Select(v => v.ShopmonkeyId).ToList();

            do
            {
                _logger.LogInformation($"Getting order from shopmonkey. Offset {offset}");
                IList<ShopmonkeyApi.Model.Orders> result = null;
                if (orderNumber.HasValue)
                    result = _client.GetOrders(isArchived: isArchived, orderNumber: orderNumber);
                else
                    result = _client.GetOrders(offset: offset, isArchived: isArchived);

                if (result == null || result.Count == 0)
                    break;

                _logger.LogInformation($"Fetched {result.Count} orders from shopmonkey.");
                var o = _mapper.Map<List<Order>>(result);
                orders.AddRange(o);

                vehicles.AddRange(o.Where(o => o.Vehicle != null && !existingVehicleIDs.Contains(o.VehicleShopmonkeyId))
                                   .Select(order => order.Vehicle).ToList());

                customers.AddRange(o.Where(o => o.Customer != null && !existingCustomerIDs.Contains(o.CustomerShopmonkeyId))
                                    .Select(order => order.Customer).ToList());

                _logger.LogInformation($"Getting jobs for each order.");
                var jobs = await GetJobsAsync(o.Where(x => x.IsArchived == isArchived).Select(x => x).AsEnumerable());
                foreach (var jobOrder in jobs)
                {
                    jobList.AddRange(jobOrder);
                    parts.AddRange(jobOrder.SelectMany(jo => jo.Parts).ToList());
                    subcontracts.AddRange(jobOrder.SelectMany(x => x.Subcontracts).ToList());
                    labors.AddRange(jobOrder.SelectMany(x => x.Labors).ToList());
                    totals.AddRange(jobOrder.Select(x => x.Total).ToList());
                }

                offset += result.Count;
                if (orderNumber.HasValue)
                    break;

            } while (true);

            var policy = Policy.Handle<Exception>()
                               .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                _logger.LogInformation($"Bulk insert is starting");

                _context.BulkInsertOrUpdate<Customer>(customers.DistinctBy(c => c.ShopmonkeyId).ToList());
                _context.BulkInsertOrUpdate<Vehicle>(vehicles.DistinctBy(v => v.ShopmonkeyId).ToList());
                _context.BulkInsertOrUpdate<Order>(orders);

                _context.BulkInsertOrUpdate<Total>(totals);
                _context.BulkInsertOrUpdate<Job>(jobList);
                _context.BulkInsertOrUpdate<Part>(parts);
                _context.BulkInsertOrUpdate<Subcontract>(subcontracts);
                _context.BulkInsertOrUpdate<Labor>(labors);

                UpdateTableInfo(new string[] { nameof(Customer), nameof(Vehicle), nameof(Order), nameof(Total)
                                             , nameof(Job), nameof(Part), nameof(Subcontract), nameof(Labor) });

                _logger.LogInformation($"Bulk insert completed");
            });
        }

        private async Task<IList<Job>[]> GetJobsAsync(IEnumerable<Order> orders)
        {
            List<Job> jobs = new List<Job>();

            var tasks = orders.Select(async order =>
            {
                var jobClient = await _client.GetJobs(order.Number.Value);
                var job = _mapper.Map<IList<Job>>(jobClient);

                job.ForAll(j =>
                {
                    j.Parts.ForAll(p => p.JobShopmonkeyId = j.ShopmonkeyId);
                    j.Subcontracts.ForAll(s => s.JobShopmonkeyId = j.ShopmonkeyId);
                    j.Labors.ForAll(l => l.JobShopmonkeyId = j.ShopmonkeyId);
                    j.Total.JobShopmonkeyId = j.ShopmonkeyId;
                    j.OrderShopmonkeyId = order.ShopmonkeyId;
                });

                return job;
            });

            var jobList = await Task.WhenAll(tasks);

            return jobList;
        }

        private void UpdateTableInfo(string[] tableNames)
        {
            var updateInfoTables = new List<UpdateInfo>();
            var date = DateTime.UtcNow;
            foreach (var tableName in tableNames)
            {
                updateInfoTables.Add(new UpdateInfo()
                {
                    TableName = tableName,
                    LastUpdatedTime = date
                });
            }

            _context.BulkInsertOrUpdate(updateInfoTables);
        }

        public void ClearDuplicatedOrder()
        {
            _logger.LogInformation("Clear duplicated order records");
            var groupedOrder = _context.Orders.GroupBy(x => x.Number).Select(x => new
            {
                Key = x.Key,
                Count = x.Count()
            }).Where(x => x.Count > 1).ToList();

            _logger.LogInformation($"{groupedOrder.Count} records found.");

            foreach (var item in groupedOrder)
            {
                var orders = _context.Orders.Include(x => x.Tags)
                    .Include(x => x.Jobs).ThenInclude(x => x.Subcontracts)
                    .Include(x => x.Jobs).ThenInclude(x => x.Parts)
                    .Include(x => x.Jobs).ThenInclude(x => x.Labors)
                    .Include(x => x.Jobs).ThenInclude(x => x.Total)
                    .Where(x => x.Number == item.Key).ToList();

                foreach (var order in orders)
                {
                    if (orders.Any(x => x.CreationDate > order.CreationDate))
                    {
                        _logger.LogInformation($"Remove oldest order record. OrderId: {order.Number}\tShopmonkeyId: {order.ShopmonkeyId}\tCreatedDate: {order.CreationDate}");

                        _context.Orders.Remove(order);
                        _context.SaveChanges();
                    }
                }
            }
        }

    }
}
