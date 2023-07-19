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
        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string folderName = "Sorted Desktop";
        public static string folderPath = Path.Combine(desktopPath, folderName);
        static void Main(string[] args)
        {
            
            Directory.CreateDirectory(folderPath);

            Console.WriteLine("Папка успешно создана.");
            DirectorySearch(desktopPath);
        }

        /// <summary>
        /// Поиск по папкам (The directory search)
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        static void DirectorySearch(string directoryPath)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(directoryPath))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        FileInfo fileInf = new FileInfo(f);
                        if (fileInf.Exists)
                        {
                            fileInf.MoveTo(folderPath);
                        }
                        Console.WriteLine(f);
                        Console.ReadKey();
                    }
                    DirectorySearch(d);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
