using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SREmulator.GUI.Model
{
    public class StringValuePair
    {
        public StringValuePair(string actualValue, string displayValue)
        {
            ActualValue = actualValue;
            DisplayValue = displayValue;
        }

        public string ActualValue { get; set; }
        public string DisplayValue { get; set; }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}
