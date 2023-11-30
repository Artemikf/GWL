using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using Gwl.Search;

namespace Gwl.FilesArchiver
{
    public class MainArchiver
    {
        public void ArchiveFiles(string rootPath, string[] fileMasks)
        {
            Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
            finder.FindFilesByMask(rootPath, fileMasks);

            // Подготавливаем папку для архивации
            string archiveDirectory = rootPath;
            Directory.CreateDirectory(archiveDirectory);

            try
            {
                // Создаем имя архива на основе имени папки
                string archiveName = $"{Path.GetFileName(rootPath)}.zip";
                string archivePath = Path.Combine(archiveDirectory, archiveName);

                // Создаем архив и добавляем в него все файлы
                using (FileStream archiveStream = new FileStream(archivePath, FileMode.Create))
                using (ZipOutputStream zipStream = new ZipOutputStream(archiveStream))
                {
                    foreach (var fileInfo in finder.Container.Files)
                    {
                        ZipEntry entry = new ZipEntry(fileInfo.Name);
                        zipStream.PutNextEntry(entry);

                        using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Open))
                        {
                            byte[] buffer = new byte[4096];
                            ICSharpCode.SharpZipLib.Core.StreamUtils.Copy(fileStream, zipStream, buffer);
                        }

                        zipStream.CloseEntry();
                    }
                }

                // Удаление оригинальных файлов
                foreach (var fileInfo in finder.Container.Files)
                {
                    File.Delete(fileInfo.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при архивации файлов: {ex.Message}");
            }
        }

    }
}
