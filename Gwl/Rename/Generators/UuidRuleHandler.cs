using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwl.Rename.Generators
{
    internal class UuidRuleHandler : IRuleHandler
    {
        public string GetValue()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
