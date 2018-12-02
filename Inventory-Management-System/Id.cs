using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory_Management_System
{
    public class Id
    {
        public string Value { get; }

        public Id(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input));
            }
            Value = input;
        }

        public bool HasOfAnyLetter(int count)
        {
            IDictionary<char, int> frequencyTable = new Dictionary<char, int>();
            foreach (var c in Value)
            {
                Add(frequencyTable, c);
            }
            // get list of all characters with the specified frequency count
            var items = frequencyTable.Values.Where(c => c == count).ToList();
            // there should be only 1 item with this frequency
            return items.Count > 0;
        }

        private void Add(IDictionary<char, int> frequencyTable, char c)
        {
            if (frequencyTable.ContainsKey(c))
            {
                frequencyTable[c] = frequencyTable[c] + 1;
            }
            else
            {
                frequencyTable[c] = 1;
            }
        }
    }
}
