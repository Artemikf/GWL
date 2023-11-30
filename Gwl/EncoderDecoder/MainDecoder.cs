using System;
using System.IO;
using Gwl.Search;

namespace Gwl.EncoderDecoder
{
    public class MainDecoder
    {
        private readonly IDecoder decoder;

        public MainDecoder(IDecoder decoder)
        {
            this.decoder = decoder ?? throw new ArgumentNullException(nameof(decoder));
        }

        public void DecodeFiles(string rootPath, string[] fileMasks)
        {
            // Используем Finder для поиска файлов
            Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
            finder.FindFilesByMask(rootPath, fileMasks);

            foreach (var fileInfo in finder.Container.Files)
            {
                try
                {
                    string decodedContent = decoder.Decode(File.ReadAllText(fileInfo.FullName));
                    File.WriteAllText(Path.Combine(fileInfo.DirectoryName, $"{fileInfo.Name}_decoder.txt"), decodedContent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при декодировании файла {fileInfo.FullName}: {ex.Message}");
                }
            }
        }
    }
}
