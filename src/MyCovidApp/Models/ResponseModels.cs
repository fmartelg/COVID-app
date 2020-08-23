using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCovidApp.Models.CovidTrackingAPI
{
    public class StateResponse
    {
        public int? date { get; set; }
        public string state { get; set; }
        public int? positive { get; set; }
        public int? negative { get; set; }
        public int? pending { get; set; }
        public int? hospitalizedCurrently { get; set; }
        public int? hospitalizedCumulative { get; set; }
        public int? inIcuCurrently { get; set; }
        public int? inIcuCumulative { get; set; }
        public int? onVentilatorCurrently { get; set; }
        public int? onVentilatorCumulative { get; set; }
        public int? recovered { get; set; }
        public string dataQualityGrade { get; set; }
        public string lastUpdateEt { get; set; }
        public string dateModified { get; set; }
        public string checkTimeEt { get; set; }
        public int? death { get; set; }
        public int? hospitalized { get; set; }
        public string dateChecked { get; set; }
        public int? totalTestsViral { get; set; }
        public int? positiveTestsViral { get; set; }
        public int? negativeTestsViral { get; set; }
        public int? positiveCasesViral { get; set; }
        public int? deathConfirmed { get; set; }
        public int? deathProbable { get; set; }
        public string fips { get; set; }
        public int? positiveIncrease { get; set; }
        public int? negativeIncrease { get; set; }
        public int? total { get; set; }
        public int? totalTestResults { get; set; }
        public int? totalTestResultsIncrease { get; set; }
        public int? posNeg { get; set; }
        public int? deathIncrease { get; set; }
        public int? hospitalizedIncrease { get; set; }
        public string hash { get; set; }
        public int? commercialScore { get; set; }
        public int? negativeRegularScore { get; set; }
        public int? negativeScore { get; set; }
        public int? positiveScore { get; set; }
        public int? score { get; set; }
        public string grade { get; set; }

        /*    "date": 20200809,
    "state": "VA",
    "positive": 100086,
    "negative": 1144172,
    "pending": 344,
    "hospitalizedCurrently": 1200,
    "hospitalizedCumulative": 14123,
    "inIcuCurrently": 260,
    "inIcuCumulative": null,
    "onVentilatorCurrently": 146,
    "onVentilatorCumulative": null,
    "recovered": 12923,
    "dataQualityGrade": "A+",
    "lastUpdateEt": "8/8/2020 17:00",
    "dateModified": "2020-08-08T17:00:00Z",
    "checkTimeEt": "08/08 13:00",
    "death": 2326,
    "hospitalized": 14123,
    "dateChecked": "2020-08-08T17:00:00Z",
    "totalTestsViral": null,
    "positiveTestsViral": null,
    "negativeTestsViral": null,
    "positiveCasesViral": 96167,
    "deathConfirmed": 2214,
    "deathProbable": 112,
    "fips": "51",
    "positiveIncrease": 897,
    "negativeIncrease": 20333,
    "total": 1244602,
    "totalTestResults": 1244258,
    "totalTestResultsIncrease": 21230,
    "posNeg": 1244258,
    "deathIncrease": 4,
    "hospitalizedIncrease": 22,
    "hash": "6fb6af7279716182461a9c465f1fda18c6356647",
    "commercialScore": 0,
    "negativeRegularScore": 0,
    "negativeScore": 0,
    "positiveScore": 0,
    "score": 0,
    "grade": ""

         */
    }
}
