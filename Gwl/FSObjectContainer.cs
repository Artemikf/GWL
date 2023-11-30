using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwl
{
    public class FSObjectContainer
    {
        public List<FileInfo> Files { get; internal set; } = new List<FileInfo>();
        public List<DirectoryInfo> Directories { get; internal set; } = new List<DirectoryInfo>();
    }
}
