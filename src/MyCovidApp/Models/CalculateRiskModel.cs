using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCovidApp.Helpers;

namespace MyCovidApp.Models
{
    public class CalculateRiskModel
    {
        private string currentDataUrl = "https://api.covidtracking.com/v1/states/{:stateCode}/current.json";
        private string dailyDataUrl = "https://api.covidtracking.com/v1/states/{:stateCode}/daily.json";
        public int httpStatusCode { get; set; }

        public async Task<CalculateRiskResponseModel> Calculate(RiskRequestModel requestModel)
        {
            CalculateRiskResponseModel retVal = new CalculateRiskResponseModel();
            httpStatusCode = StatusCodes.Status200OK;

            try
            {
                retVal.numberOfPeople = requestModel.numberOfPeople;
                if (requestModel.locationToSearch == "AAA")
                {
                    retVal.positivityRate = requestModel.positivityRate / 100;
                }
                else
                {
                    //calculate the positivity rate from the last 7 days
                    List<CovidTrackingAPI.StateResponse> stateDailyResponse = await StateDailyData(requestModel.locationToSearch);
                    if (httpStatusCode != StatusCodes.Status200OK)
                    {
                        httpStatusCode = StatusCodes.Status500InternalServerError;
                        return retVal;
                    }
                    retVal.positivityRate = SevenDayAveragePositiveTestRate(stateDailyResponse);
                    //CovidTrackingAPI.StateResponse stateResponse = await StateCurrentData(requestModel.locationToSearch);
                    //int total = (int)stateResponse.totalTestResults;
                    //int positive = (int)stateResponse.positive;
                    //retVal.positivityRate = (float)positive / total;
                }
                //compute probability
                int numberOfTrials = (int)requestModel.numberOfPeople;
                int successCount = 0;   //0 persons are positive
                double probability = Distributions.dbinom(successCount, numberOfTrials, (double)retVal.positivityRate);
                //at least one person is positive: 1-P(x=0)
                probability = 1 - probability;
                //double probability = BinomialProbability(numberOfTrials, successCount, (float)retVal.positivityRate);
                retVal.probabilityAtLeastOne = probability * 100;
                retVal.probabilityZero = 100 - retVal.probabilityAtLeastOne;
                retVal.positivityRate = 100 * retVal.positivityRate;
            }
            catch
            {
                httpStatusCode = StatusCodes.Status500InternalServerError;
                return retVal;
            }

            return retVal;
        }

        public async Task<CovidTrackingAPI.StateResponse> StateCurrentData(string stateCode)
        {
            CovidTrackingAPI.StateResponse retVal = new CovidTrackingAPI.StateResponse();

            string callURL = currentDataUrl.Replace("{:stateCode}", stateCode);
            APICallUtility callUtility = new APICallUtility();
            HttpResponseMessage responseMessage = await callUtility.Get(callURL);

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                httpStatusCode = (int)responseMessage.StatusCode;
                return retVal;
            }
            string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
            retVal = JsonSerializer.Deserialize<CovidTrackingAPI.StateResponse>(responseJson);

            return retVal;
        }

        public async Task<List<CovidTrackingAPI.StateResponse>> StateDailyData(string stateCode)
        {
            List<CovidTrackingAPI.StateResponse> retVal = new List<CovidTrackingAPI.StateResponse>();

            string callURL = dailyDataUrl.Replace("{:stateCode}", stateCode);
            APICallUtility callUtility = new APICallUtility();
            HttpResponseMessage responseMessage = await callUtility.Get(callURL);

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                httpStatusCode = (int)responseMessage.StatusCode;
                return retVal;
            }
            string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
            retVal = JsonSerializer.Deserialize<List<CovidTrackingAPI.StateResponse>>(responseJson);

            return retVal;
        }

        private float SevenDayAveragePositiveTestRate(List<CovidTrackingAPI.StateResponse> dailyData)
        {
            float retVal = 0;
            //get the average test rate for seven days - it's supposed to be in decreasing order
            int i = 0;
            int positiveIncreaseTotal = 0;
            int negativeIncreaseTotal = 0;
            foreach (CovidTrackingAPI.StateResponse response in dailyData)
            {
                if (i < 7)
                {
                    bool validCalc = true;
                    if (response.positiveIncrease == null)
                    {
                        validCalc = false;
                    }
                    if (response.negativeIncrease == null)
                    {
                        validCalc = false;
                    }
                    if (validCalc)
                    {
                        positiveIncreaseTotal += (int)response.positiveIncrease;
                        negativeIncreaseTotal += (int)response.negativeIncrease;
                        i++;
                    }
                }
            }
            //get the denominator ie the total
            int totalTests = positiveIncreaseTotal + negativeIncreaseTotal;
            if (totalTests > 0)
            {
                retVal = (float)positiveIncreaseTotal / (float)totalTests;
            }
            return retVal;
        }

        private double BinomialProbability(int numberOfTrials, int successCount, double probabilityOfSuccess)
        {
            //n: The number of trials in the binomial experiment.
            //x: The number of successes that result from the binomial experiment.
            //P: The probability of success on an individual trial.
            //n and x are integers

            int n = numberOfTrials;
            int x = successCount;
            double p = probabilityOfSuccess;

            //b(x; n, P) = { n! / [ x! (n - x)! ] } * P^x * (1 - P)^(n - x)
            long nFactorial = factorial(n);
            long xFactorial = factorial(x);
            int nMinusX = n - x;
            long nMinusXFactorial = factorial(nMinusX);
            double value1 = nFactorial / (xFactorial * nMinusXFactorial);
            double value2 = Math.Pow(p, x);
            double oneMinusP = (1 - p);
            double value3 = Math.Pow(oneMinusP, nMinusX);

            double retVal = value1 * value2 * value3;

            return retVal;
        }

        private long factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result = result * i;
            }
            return result;
        }
    }
}
