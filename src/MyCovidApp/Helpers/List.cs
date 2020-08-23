using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using MyCovidApp.Models;

namespace MyCovidApp.Helpers
{
    public class List
    {
        public List<Area> StatesForDropdown()
        {
            List<Area> retVal = new List<Area>();

            Hashtable hashTable = new Hashtable();
            hashTable.Add("AAA", "None");
            hashTable.Add("AL", "Alabama");
            hashTable.Add("AK", "Alaska");
            hashTable.Add("AS", "American Samoa");
            hashTable.Add("AZ", "Arizona");
            hashTable.Add("AR", "Arkansas");
            hashTable.Add("CA", "California");
            hashTable.Add("CO", "Colorado");
            hashTable.Add("CT", "Connecticut");
            hashTable.Add("DE", "Delaware");
            hashTable.Add("DC", "Dist of Columbia");
            hashTable.Add("FL", "Florida");
            hashTable.Add("GA", "Georgia");
            hashTable.Add("GU", "Guam");
            hashTable.Add("HI", "Hawaii");
            hashTable.Add("ID", "Idaho");
            hashTable.Add("IL", "Illinois");
            hashTable.Add("IN", "Indiana");
            hashTable.Add("IA", "Iowa");
            hashTable.Add("KS", "Kansas");
            hashTable.Add("KY", "Kentucky");
            hashTable.Add("LA", "Louisiana");
            hashTable.Add("ME", "Maine");
            hashTable.Add("MD", "Maryland");
            hashTable.Add("MA", "Massachusetts");
            hashTable.Add("MI", "Michigan");
            hashTable.Add("MN", "Minnesota");
            hashTable.Add("UM", "Minor Outlying Islands");
            hashTable.Add("MS", "Mississippi");
            hashTable.Add("MO", "Missouri");
            hashTable.Add("MT", "Montana");
            hashTable.Add("NE", "Nebraska");
            hashTable.Add("NV", "Nevada");
            hashTable.Add("NH", "New Hampshire");
            hashTable.Add("NJ", "New Jersey");
            hashTable.Add("NM", "New Mexico");
            hashTable.Add("NY", "New York");
            hashTable.Add("NC", "North Carolina");
            hashTable.Add("ND", "North Dakota");
            hashTable.Add("MP", "Northern Mariana Islands");
            hashTable.Add("OH", "Ohio");
            hashTable.Add("OK", "Oklahoma");
            hashTable.Add("OR", "Oregon");
            hashTable.Add("PA", "Pennsylvania");
            hashTable.Add("PR", "Puerto Rico");
            hashTable.Add("RI", "Rhode Island");
            hashTable.Add("SC", "South Carolina");
            hashTable.Add("SD", "South Dakota");
            hashTable.Add("TN", "Tennessee");
            hashTable.Add("TX", "Texas");
            hashTable.Add("UT", "Utah");
            hashTable.Add("VT", "Vermont");
            hashTable.Add("VA", "Virginia");
            hashTable.Add("VI", "U.S. Virgin Islands");
            hashTable.Add("WA", "Washington");
            hashTable.Add("WV", "West Virginia");
            hashTable.Add("WI", "Wisconsin");
            hashTable.Add("WY", "Wyoming");

            List<Area> unsorted = new List<Area>();
            foreach (DictionaryEntry ht in hashTable)
            {
                Area area = new Area
                {
                     abbreviation = ht.Key.ToString(),
                     name = ht.Value.ToString()
                };
                unsorted.Add(area);
            }
            retVal = unsorted.OrderBy(a => a.abbreviation).ToList();
            return retVal;
        }
    }
}
