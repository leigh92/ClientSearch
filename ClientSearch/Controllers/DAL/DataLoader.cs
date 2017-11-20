using System.Collections.Generic;
using RestSharp;
using ClientSearch.Models;


namespace ClientSearch.DAL
{
    public class DataLoader
    {
        public List<ApiClient> GetClients() //retrieves data from API
        {
            var client = new RestClient("http://api-gateway-dev.phorest.com");
            var request = new RestRequest("/third-party-api-server/api/business/eTC3QY5W3p_HmGHezKfxJw/client");

            request.AddHeader("Authorization", "Basic Z2xvYmFsL2Nsb3VkQGFwaWV4YW1wbGVzLmNvbTpWTWxSby9laCtYZDhNfmw=");

            var response = client.Execute<ApiData>(request);

            return response.Data._embedded.clients;
        }

    }
}