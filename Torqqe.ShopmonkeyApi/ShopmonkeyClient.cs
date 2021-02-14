using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Torqqe.ShopmonkeyApi.Helper;
using Torqqe.ShopmonkeyApi.Model;

namespace Torqqe.ShopmonkeyApi
{
    public class ShopmonkeyClient
    {
        private readonly string _baseUrl;
        private readonly string _publicKey;
        private readonly string _privateKey;
        public ShopmonkeyClient(string baseUrl, string publicKey, string privateKey)
        {
            _baseUrl = baseUrl;
            _publicKey = publicKey;
            _privateKey = privateKey;
        }

        public IList<Customer> GetCustomers(int limit = 100, int offset = 0)
        {
            var client = new RestClient($"{_baseUrl}/customers");

            string xdate = DateTime.Now.GetXDate();
            string input = $"{_publicKey}\n{xdate}";
            string signature = HMACSignature.GenerateSignature(input, _privateKey);

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("publickey", _publicKey);
            request.AddHeader("xdate", xdate);
            request.AddHeader("signature", signature);

            request.AddQueryParameter("includeShopmonkeyCustomers", "true");

            request.AddQueryParameter("sort", "creationDate");
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("offset", offset.ToString());

            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            var result = JsonConvert.DeserializeObject<List<Customer>>(response.Content);

            return result;
        }

        public async Task<IList<Jobs>> GetJobs(int? orderNumber)
        {
            if (!orderNumber.HasValue)
                return null;

            var client = new RestClient($"{_baseUrl}/orders/{orderNumber}/jobs");

            string xdate = DateTime.Now.GetXDate();
            string input = $"{_publicKey}\n{xdate}";
            string signature = HMACSignature.GenerateSignature(input, _privateKey);

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("publickey", _publicKey);
            request.AddHeader("xdate", xdate);
            request.AddHeader("signature", signature);


            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            var result = JsonConvert.DeserializeObject<List<Jobs>>(response.Content);

            return result;
        }

        public IList<Orders> GetOrders(int limit = 100, int offset = 0, bool isArchived = false, int? orderNumber = null)
        {
            var client = new RestClient($"{_baseUrl}/orders");

            string xdate = DateTime.Now.GetXDate();
            string input = $"{_publicKey}\n{xdate}";
            string signature = HMACSignature.GenerateSignature(input, _privateKey);

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("publickey", _publicKey);
            request.AddHeader("xdate", xdate);
            request.AddHeader("signature", signature);

            request.AddQueryParameter("isArchived", isArchived.ToString());
            request.AddQueryParameter("sort", "creationDate");
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("offset", offset.ToString());
            if (orderNumber.HasValue)
                request.AddQueryParameter("number", orderNumber.Value.ToString());

            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            var result = JsonConvert.DeserializeObject<List<Orders>>(response.Content);

            return result;
        }

        public IList<Vehicle> GetVehicle(int limit = 100, int offset = 0)
        {
            var client = new RestClient($"{_baseUrl}/vehicles");

            string xdate = DateTime.Now.GetXDate();
            string input = $"{_publicKey}\n{xdate}";
            string signature = HMACSignature.GenerateSignature(input, _privateKey);

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("publickey", _publicKey);
            request.AddHeader("xdate", xdate);
            request.AddHeader("signature", signature);

            request.AddQueryParameter("includeShopmonkeyVehicles", "true");

            request.AddQueryParameter("sort", "creationDate");
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("offset", offset.ToString());

            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            var result = JsonConvert.DeserializeObject<List<Vehicle>>(response.Content);

            return result;
        }
    }
}
