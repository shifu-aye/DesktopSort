using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DesktopSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string folderName = "Sorted Desktop";
            DirectorySearch(desktopPath, folderName);
        }

        /// <summary>
        /// Поиск по папкам (The directory search)
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        static void DirectorySearch(string desktopPath, string folderName)
        {
            try
            {
                string folderPath = Path.Combine(desktopPath, folderName);

                // Получаем список файлов в исходной папке с указанным типом
                string[] files = Directory.EnumerateFiles(desktopPath).ToArray();

                // Создаем целевую папку, если она не существует
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Перемещаем каждый файл в целевую папку
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destination = Path.Combine(folderPath, fileName);
                    File.Move(file, destination);
                    Console.WriteLine($"Файл {fileName} перемещен в папку {folderPath}");
                }

                Console.WriteLine("Перемещение файлов завершено.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
