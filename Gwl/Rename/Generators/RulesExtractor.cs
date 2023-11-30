using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gwl.Rename.Generators
{
    internal class RulesExtractor
    {
        private const string SIGNATURE_PATTERN = @"\<([^>]+)\>";
        private const string SHORTCUT_PATTERN = @"^\w+";
        private const string PARAMETERS_PATTERN = @"\((.*)\)";

        public class RuleItem
        {
            public string Signature { get; set; } = null!;
            public string Shortcut { get; set; } = null!;
            public string Parameters { get; set; } = null!;
        }

        private Regex signatureRegex = new Regex(SIGNATURE_PATTERN);
        private Regex shortcutRegex = new Regex(SHORTCUT_PATTERN);
        private Regex parametersRegex = new Regex(PARAMETERS_PATTERN);

        public List<RuleItem> Extract(string replacePattern)
        {
            List<RuleItem> result = new List<RuleItem>();

            foreach(Match m in signatureRegex.Matches(replacePattern))
            {
                string signature = m.Groups[1].Value;

                result.Add(new RuleItem()
                {
                    Signature = signature,
                    Shortcut = shortcutRegex.Match(signature).Value,
                    Parameters = parametersRegex.Match(signature).Value
                });
            }

            return result;
        }
    }
}
