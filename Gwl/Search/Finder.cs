using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwl.Search
{
    public class Finder
    {
        public enum AnalyzerStrategy
        {
            RegexStrategy,
        }
        public FSObjectContainer Container { get; private set; }

        internal IFileAnalyzer FileAnalyzer { get; private set; }

        public Finder(AnalyzerStrategy strategy)
        {
            Container = new FSObjectContainer();

            FileAnalyzer = strategy switch
            {
                AnalyzerStrategy.RegexStrategy => new RegexFileAnalyzer(),

                _ => throw new NotSupportedException(),
            };
        }

        public void FindFilesByCondition(string rootPath, Predicate<FileInfo> predicate)
        {
            DirectoryInfo root = new DirectoryInfo(rootPath);

            FileInfo[] files = root.GetFiles();
            DirectoryInfo[] dirs = root.GetDirectories();

            foreach (FileInfo file in files)
            {
                if (predicate(file))
                    Container.Files.Add(file);
            }

            foreach (DirectoryInfo dir in dirs)
                FindFilesByCondition(dir.FullName, predicate);
        }
        public void FindDirectoriesByCondition(string rootPath, Predicate<DirectoryInfo> predicate)
        {
            DirectoryInfo root = new DirectoryInfo(rootPath);

            DirectoryInfo[] dirs = root.GetDirectories();

            foreach (DirectoryInfo dir in dirs)
                if (predicate(dir))
                    Container.Directories.Add(dir);
                else
                    FindDirectoriesByCondition(dir.FullName, predicate);
        }

        public void FindFilesByMask(string rootPath, string[] fileMasks)
        {
            DirectoryInfo root = new DirectoryInfo(rootPath);

            DirectoryInfo[] dirs = root.GetDirectories();
            FileInfo[] files = root.GetFiles();

            Container.Files.AddRange(FileAnalyzer.AnalyzeFiles(files, fileMasks));

            foreach (DirectoryInfo dir in dirs)
                FindFilesByMask(dir.FullName, fileMasks);
        }

        public void FindDirectoriesByMask(string rootPath, string[] dirMasks)
        {
            DirectoryInfo root = new DirectoryInfo(rootPath);

            DirectoryInfo[] dirs = root.GetDirectories();

            foreach(DirectoryInfo d in dirs)
                if (dirMasks.Contains(d.Name))
                    Container.Directories.Add(d);
                else
                    FindDirectoriesByMask(d.FullName, dirMasks);
        }

    }
}
