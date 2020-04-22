using System;
using System.IO;

namespace RenameTest
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Rename Media Utility v1.0";
            Console.WriteLine("Введите путь к директории.");
            string directory = Console.ReadLine();
            Console.WriteLine();
            string[] allFilesName = Directory.GetFiles(directory);
            foreach (string i in allFilesName)
            {
                var nameWork = i.Substring(directory.Length + 1); //Присвоение имени файла переменной
                if (nameWork.Length > 22) //Проверка длинны имени файла
                {
                    Console.WriteLine("Имя текущего файла: {0}", nameWork);
                    nameWork = nameWork.Replace("IMG_", String.Empty);
                    nameWork = nameWork.Replace("VID_", String.Empty);
                    nameWork = nameWork.Insert(4, ".");
                    nameWork = nameWork.Insert(7, ".");
                    nameWork = nameWork.Insert(13, "-");
                    nameWork = nameWork.Insert(16, "-");
                    Console.WriteLine("Новое имя файла:    {0}", nameWork);
                    string newFile = String.Format(@"{0}\{1}", directory, nameWork); 
                    File.Move(i, newFile);
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Файл не нуждается в переименовании. {0}\n", nameWork);
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Программа успешно завершила свою работу. Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
