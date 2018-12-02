using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public class Analyzer
    {
        private readonly IList<Id> _input;

        public Analyzer(IList<Id> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            _input = input;
        }

        public string GetCommonLetters()
        {
            var comparisonTable = new Dictionary<string, List<string>>();
            // first process all Ids by comparing them to all the other Ids and finding the ones with 1 char difference
            foreach (var currentId in _input)
            {
                foreach (var id in _input)
                {
                    if (currentId.DiffersOneCharWith(id))
                    {
                        Add(comparisonTable, currentId, id);
                    }
                }
            }
            // now we find the table items that have only 1 item their list
            var keys = comparisonTable.Keys.Where(key => comparisonTable[key].Count == 1).ToList();
            if (keys.Count == 2)
            {
                return GetCommonCharacters(keys.First(), keys.Last());
            }
            return string.Empty;
        }


        public string GetCommonCharacters(string value1, string value2)
        {
            var commonChars = string.Empty;
            for (var i = 0; i < value1.Length; i++)
            {
                if (value1[i] == value2[i])
                {
                    commonChars += value1[i];
                }
            }
            return commonChars;
        }


        private void Add(IDictionary<string, List<string>> comparisonTable, Id currentId, Id id)
        {
            List<string> items = new List<string>(); 
            if (comparisonTable.ContainsKey(currentId.Value))
            {
                items = comparisonTable[currentId.Value];
            }
            items.Add(id.Value);
            comparisonTable[currentId.Value] = items;
        }
    }
}
