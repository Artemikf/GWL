using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gwl.Search;

namespace Gwl.DataCleaner
{
    public class MainCleaner : ICleaner
    {
        public void DeleteFilesInDirectory(string rootPath, string[] fileMasks)
        {
            Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
            finder.FindFilesByMask(rootPath, fileMasks);

            foreach (var file in finder.Container.Files)
            {
                try
                {
                    File.Delete(file.FullName);
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Ошибка при удалении файла {file.FullName}: {ex.Message}");
                }
            }
        }
    }
}
