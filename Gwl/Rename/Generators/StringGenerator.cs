using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gwl.Rename.Generators.RulesExtractor;

namespace Gwl.Rename.Generators
{
    internal class StringGenerator
    {
        private string replacePattern = string.Empty;
        private RulesExtractor rulesExtractor;
        private List<RuleItem> ruleItems = null!;

        private Dictionary<string, IRuleHandler> handlers = new Dictionary<string, IRuleHandler>()
        {
            { "uuid", new UuidRuleHandler() },
            { "increment", new IncrementRuleHandler() }
        };

        public StringGenerator()
        {
            rulesExtractor = new RulesExtractor();
        }


        public void SetReplacePattern(string replacePattern)
        {
            this.replacePattern = replacePattern;

            ruleItems = rulesExtractor.Extract(replacePattern);

            ConfigureHandlers();
        }

        private void ConfigureHandlers()
        {
            ruleItems.ForEach(item =>
            {
                IRuleHandler handler = handlers[item.Shortcut];

                if (!string.IsNullOrEmpty(item.Parameters))
                {
                    if (handler is IWIthParameters h)
                        h.ParametersString = item.Parameters;
                }
            });
        }

        public string GetNext()
        {
            string result = replacePattern;

            ruleItems.ForEach(item =>
            {
                IRuleHandler handler = handlers[item.Shortcut];

                string value = handler.GetValue();
                result = result.Replace(item.Signature, value);
            });

            return result;
        }

    }
}
