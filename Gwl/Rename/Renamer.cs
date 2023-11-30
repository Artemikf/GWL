using Gwl.Rename.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwl.Rename
{
    public class Renamer
    {
        public FSObjectContainer Container { get; private set; }
        private StringGenerator Generator { get; set; }

        public Renamer(FSObjectContainer container)
        {
            Container = container;
            Generator = new StringGenerator();
        }

        public void RenameFiles(string generatePattern)
        {
            foreach (var file in Container.Files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FullName);
                string fileExtension = Path.GetExtension(file.FullName);

                Generator.SetReplacePattern(generatePattern);
                string newName = Generator.GetNext();

                string newFileName = $"{newName}{fileExtension}";
                string newPath = Path.Combine(file.Directory.FullName, newFileName);

                File.Move(file.FullName, newPath);
            }
        }
    }
}
