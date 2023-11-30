using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwl.Rename.Generators
{
    internal class IncrementRuleHandler : IRuleHandler, IWIthParameters
    {
        private int from;
        private int step;
        private int current;

        private string parametetrsString = string.Empty;
        public string ParametersString { 
            get
            {
                return parametetrsString;
            }
            set
            {
                parametetrsString = value;
                ParseParametersString();
            }
        }

        public string GetValue()
        {
            current += step;

            return current.ToString();
        }

        private void ParseParametersString()
        {
            string[] items = parametetrsString.Split(',');

            from = Convert.ToInt32(items[0]);
            step = Convert.ToInt32(items[1]);
            current = from;
        }
    }
}
