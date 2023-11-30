using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gwl.Search
{
    internal class RegexFileAnalyzer : IFileAnalyzer
    {
        private Dictionary<string, string> map = new Dictionary<string, string>()
        {
            { ".", @"\." },
            { "^", @"\^" },
            { "+", @"\+" },
            { "{", @"\{" },
            { "}", @"\}" },
            { "[", @"\[" },
            { "]", @"\]" },
            { "(", @"\(" },
            { ")", @"\)" },

            { "*", ".*" },
            { "?", "." },
        };

        public List<FileInfo> AnalyzeFiles(FileInfo[] files, string[] masks)
        {
            List<FileInfo> result = new List<FileInfo>();

            string pattern = PreparePattern(masks);

            Regex regex = new Regex(pattern);

            foreach(FileInfo f in files)
                if (regex.IsMatch(f.Name))
                    result.Add(f);

            return result;
        }

        private string PreparePattern(string[] masks)
        {
            List<string> patterns = new List<string>();

            foreach (string mask in masks)
                patterns.Add(ConvertMaskToValidPattern(mask));


            return $"({String.Join('|', patterns)})";
        }

        private string ConvertMaskToValidPattern(string mask)
        {
            foreach(KeyValuePair<string, string> item in map)
                mask = mask.Replace(item.Key, item.Value);

            mask = $"^{mask}$";

            return mask;
        }
    }
}
