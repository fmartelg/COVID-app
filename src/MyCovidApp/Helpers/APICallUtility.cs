using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyCovidApp.Helpers
{
    public class APICallUtility
    {
        public async Task<HttpResponseMessage> Get(string URL)
        {
            HttpResponseMessage retVal = new HttpResponseMessage();
            HttpClient httpClient = new HttpClient();

            //set the client details
            httpClient.BaseAddress = new Uri(URL);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            retVal = await httpClient.GetAsync("");
            return retVal;
        }

    }
}
