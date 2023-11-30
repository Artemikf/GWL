using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwl.FilesGroupper
{
    public interface IGroupper
    {
        void GroupFilesByMonthYearCreate(string rootPath, string[] fileMasks);
        void GroupFilesByYearCreate(string rootPath, string[] fileMasks);
        void GroupFilesByMonthYearEdit(string rootPath, string[] fileMasks);
        void GroupFilesByYearEdit(string rootPath, string[] fileMasks);

    }
}
