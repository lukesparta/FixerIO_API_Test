using System;
using System.Diagnostics;
using RestSharp; //used to make a call

namespace Fixerio
{ 
    public class FixerLatestCallManager
    {
        readonly IRestClient client;

        public FixerLatestCallManager()
        {
            client = new RestClient(FixerConfig.baseURL);
        }

        public string GetLatestRates()
        {
            var request = new RestRequest("/latest" + FixerConfig.ApiUrlMod + FixerConfig.ApiKey);
            var response = client.Execute(request, Method.GET);
            Trace.WriteLine(response.Content);
            return response.Content;
        }
    }

    
}
