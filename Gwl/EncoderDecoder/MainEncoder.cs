using System;
using System.IO;
using Gwl.Search;

namespace Gwl.EncoderDecoder
{
    public class MainEncoder
    {
        private readonly IEncoder encoder;

        public MainEncoder(IEncoder encoder)
        {
            this.encoder = encoder ?? throw new ArgumentNullException(nameof(encoder));
        }

        public void EncodeFiles(string rootPath, string[] fileMasks)
        {
            // Используем Finder для поиска файлов
            Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
            finder.FindFilesByMask(rootPath, fileMasks);

            foreach (var fileInfo in finder.Container.Files)
            {
                try
                {
                    string encodedContent = encoder.Encode(File.ReadAllText(fileInfo.FullName));
                    File.WriteAllText(Path.Combine(fileInfo.DirectoryName, $"{fileInfo.Name}_encoder.txt"), encodedContent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при кодировании файла {fileInfo.FullName}: {ex.Message}");
                }
            }
        }
    }
}
