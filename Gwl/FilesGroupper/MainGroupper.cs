using System;
using System.Collections.Generic;
using System.IO;
using Gwl.Search;

namespace Gwl.FilesGroupper
{
    public class MainGroupper : IGroupper
    {
        public void GroupFilesByMonthYearCreate(string rootPath, string[] fileMasks)
        {
            // Используем Finder для поиска файлов
            Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
            finder.FindFilesByMask(rootPath, fileMasks);

            // Подготавливаем папку для группировки
            string groupedDirectory = Path.Combine(rootPath, "GroupedFiles");
            Directory.CreateDirectory(groupedDirectory);

            foreach (var fileInfo in finder.Container.Files)
            {
                try
                {
                    // Получаем месяц и год создания файла
                    int year = fileInfo.CreationTime.Year;
                    int month = fileInfo.CreationTime.Month;

                    // Создаем папку с именем вида "month_year"
                    string groupFolder = $"{GetMonthName(month)}_{year}";
                    string groupFolderPath = Path.Combine(groupedDirectory, groupFolder);
                    Directory.CreateDirectory(groupFolderPath);

                    // Перемещаем файл в соответствующую папку
                    string destinationPath = Path.Combine(groupFolderPath, fileInfo.Name);
                    File.Move(fileInfo.FullName, destinationPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при группировке файла {fileInfo.FullName}: {ex.Message}");
                }
            }
        }

        public void GroupFilesByYearCreate(string rootPath, string[] fileMasks)
        {
            Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
            finder.FindFilesByMask(rootPath, fileMasks);

            foreach (var fileInfo in finder.Container.Files)
            {
                try
                {
                    int year = fileInfo.CreationTime.Year;

                    string yearFolder = Path.Combine(rootPath, $"{year}");
                    Directory.CreateDirectory(yearFolder);

                    string destinationPath = Path.Combine(yearFolder, fileInfo.Name);
                    File.Move(fileInfo.FullName, destinationPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при группировке файла {fileInfo.FullName}: {ex.Message}");
                }
            }

        }

        public void GroupFilesByMonthYearEdit(string rootPath, string[] fileMasks)
        {
            Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
            finder.FindFilesByMask(rootPath, fileMasks);

            string groupedDirectory = Path.Combine(rootPath, "GroupedFiles");
            Directory.CreateDirectory(groupedDirectory);

            foreach (var fileInfo in finder.Container.Files)
            {
                try
                {
                    int year = fileInfo.LastWriteTime.Year;
                    int month = fileInfo.LastWriteTime.Month;

                    string groupFolder = $"{GetMonthName(month)}_{year}";
                    string groupFolderPath = Path.Combine(groupedDirectory, groupFolder);
                    Directory.CreateDirectory(groupFolderPath);

                    string destinationPath = Path.Combine(groupFolderPath, fileInfo.Name);
                    File.Move(fileInfo.FullName, destinationPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при группировке файла {fileInfo.FullName}: {ex.Message}");
                }
            }
        }

        public void GroupFilesByYearEdit(string rootPath, string[] fileMasks)
        {
            // Используем Finder для поиска файлов
            Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
            finder.FindFilesByMask(rootPath, fileMasks);

            foreach (var fileInfo in finder.Container.Files)
            {
                try
                {
                    // Получаем год последнего изменения файла
                    int year = fileInfo.LastWriteTime.Year;

                    // Создаем папку для года, если ее нет
                    string yearFolder = Path.Combine(rootPath, $"{year}");
                    Directory.CreateDirectory(yearFolder);

                    // Перемещаем файл в папку для года
                    string destinationPath = Path.Combine(yearFolder, fileInfo.Name);
                    File.Move(fileInfo.FullName, destinationPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при группировке файла {fileInfo.FullName}: {ex.Message}");
                }
            }


        }
        
        // Вспомогательный метод для получения названия месяца по его номеру
        private string GetMonthName(int month)
        {
            return new DateTime(2000, month, 1).ToString("MMMM");
        }
    }
}
