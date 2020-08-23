using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCovidApp.Helpers;

namespace MyCovidApp.Models
{
    public class RiskRequestModel
    {
        public double? positivityRate { get; set; }
        public string locationToSearch { get; set; }
        public int? numberOfPeople { get; set; }
        public SelectList ListOfStates { get; set; }

        public RiskRequestModel()
        {
            List list = new List();
            List<Area> areas = list.StatesForDropdown();
            ListOfStates = new SelectList(areas, "abbreviation", "name");
        }
    }

    public class CalculateRiskResponseModel
    {
        public double? positivityRate { get; set; }
        public int? numberOfPeople { get; set; }
        public double? probabilityAtLeastOne { get; set; }
        public double? probabilityZero { get; set; }
    }
}
