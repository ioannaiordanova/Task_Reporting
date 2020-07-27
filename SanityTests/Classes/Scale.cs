using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SanityTests
{
    class Scale
    {
        static readonly List<string> ValuesList = new List<string>() { "0.1", "0.25", "0.5", "0.75", "1", "1.5", "2", "4", "8" };
        
        public int GetPreviousIndex(string currentValue)
        {
            return (0 == ValuesList.IndexOf(currentValue)) ?
                ValuesList.IndexOf(currentValue)
            :
                ValuesList.IndexOf(currentValue) - 1;
        }

        public string GetNext(string currentValue)
        {
            return ValuesList[GetNextIndex(currentValue)];
        }

        public string GetPrevious(string currentValue)
        {
            return ValuesList[GetPreviousIndex(currentValue)];
        }


        private int GetNextIndex(string currentValue)
        {
            return (ValuesList.Count == (ValuesList.IndexOf(currentValue) + 1)) ?
                ValuesList.IndexOf(currentValue)
            :
                ValuesList.IndexOf(currentValue) + 1;
        }

    }
}
