using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwl.DataCleaner
{
    public interface ICleaner
    {
        void DeleteFilesInDirectory(string rootPath, string[] fileMasks);
    }
}
