using System;
using Newtonsoft.Json;

namespace Fixerio
{
    public class FixerLatestDTO { 
    
        public LatestRatesRoot LatestRates { get; set; }

        public void DeserializeLatestRates(string LatestRatesResponse)
        {
            LatestRates = JsonConvert.DeserializeObject<LatestRatesRoot>(LatestRatesResponse);
        }
    }
}
