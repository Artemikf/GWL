using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwl.Search
{
    internal interface IFileAnalyzer
    {
        public List<FileInfo> AnalyzeFiles(FileInfo[] files, string[] masks);
    }
}
