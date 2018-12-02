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

        public bool DiffersOneCharWith(Id input)
        {
            // two IDs should be same length
            if (Value.Length != input.Value.Length)
            {
                return false;
            }
            // same IDs always return false
            if (Value == input.Value)
            {
                return false;
            }
            var diffCount = 0;
            var index = 0;
            // compare char by char, stop when input length reached or #different characters exceeds 1
            while ((diffCount <= 1) && (index < Value.Length))
            {
                if (Value[index] != input.Value[index])
                {
                    diffCount++;
                }
                index++;
            }
            return (diffCount == 1);
        }

        public bool HasOfAnyLetter(int count)
        {
            IDictionary<char, int> frequencyTable = new Dictionary<char, int>();
            foreach (var c in Value)
            {
                Add(frequencyTable, c);
            }
            // true if the requested frequency count appears at least once
            return frequencyTable.Values.Any(c => c == count);
        }

        private static void Add(IDictionary<char, int> frequencyTable, char c)
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
