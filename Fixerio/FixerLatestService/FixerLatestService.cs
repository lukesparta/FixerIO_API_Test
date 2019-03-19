using System;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fixerio
{
    public class FixerLatestService
    {
        //Call manager
        public FixerLatestCallManager fixerLatestCallManager = new FixerLatestCallManager();

        //desteralisation (Data Transfer Objet)
        public FixerLatestDTO fixerLatestDTO = new FixerLatestDTO();

        public JObject LatestRatesJson;
        public JObject RatesCount;

        public FixerLatestService()
        {
            fixerLatestDTO.DeserializeLatestRates(fixerLatestCallManager.GetLatestRates()); //response from api 
        }

        public int getRates()
        {
            int ratesCount = 0;
            //
            LatestRatesJson = JObject.Parse(fixerLatestCallManager.GetLatestRates());
            RatesCount = JObject.Parse(LatestRatesJson["rates"].ToString());

            foreach (var rate in RatesCount)
            {
                ratesCount++;
            }

            return ratesCount;
        }

        public bool checkIfFloat()
        {
            LatestRatesJson = JObject.Parse(fixerLatestCallManager.GetLatestRates());
            RatesCount = JObject.Parse(LatestRatesJson["rates"].ToString());
            bool check = true;
            foreach (var rate in RatesCount.Properties())
            {
                if (rate.Value.Type != JTokenType.Float)
                {
                    check = false;
                }
                break;
            }
            return check;
        }

        public bool baseCheck()
        {
            LatestRatesJson = JObject.Parse(fixerLatestCallManager.GetLatestRates());
            string b = LatestRatesJson["base"].ToString();
            int count = 0;
            for(int i = 0; i < b.Length; i++)
            {
                count++;
            }

            return Regex.IsMatch(b, @"^[a-zA-Z]+$") && count == 3 ? true : false;
        }

        public bool dateCheck()
        {
            LatestRatesJson = JObject.Parse(fixerLatestCallManager.GetLatestRates());
            string date = LatestRatesJson["date"].ToString();
            DateTime today = DateTime.Today;
           if(today.ToString("yyyy-MM-dd") == date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool timeStampCheck()
        {
            LatestRatesJson = JObject.Parse(fixerLatestCallManager.GetLatestRates());
            string apiTS = LatestRatesJson["timestamp"].ToString();
            long timeStamp = (Convert.ToInt64(apiTS+"000"));
            bool isNumber = long.TryParse(apiTS, out long n);
            DateTime result = DateTimeOffset.FromUnixTimeMilliseconds(timeStamp).DateTime;
            DateTime date = DateTime.Now;
            if(result.Year == date.Year && result.Month == date.Month && result.Day == date.Day)
            {
                return true;
            }
            return false;
        }
    }
}
