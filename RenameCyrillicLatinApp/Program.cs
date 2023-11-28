using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter the path of the directory: ");
        var directoryPath = Console.ReadLine();

        if (Directory.Exists(directoryPath))
        {
            RenameFilesAndFolders(directoryPath);

            Console.WriteLine("Renaming completed successfully.");
        }
        else
        {
            Console.WriteLine("Directory not found.");
        }

        static void RenameFilesAndFolders(string directoryPath)
        {
            var files = Directory.GetFiles(directoryPath);
            var folders = Directory.GetDirectories(directoryPath);

            foreach (var file in files)
            {
                RenameFile(file);
            }

            foreach (var folder in folders)
            {
                RenameFolder(folder);
            }
        }

        static void RenameFile(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            string oldName = Path.GetFileName(path);
            string newName = ConvertCyrillicToLatin(oldName);

            if (oldName != newName)
            {
                string newPath = Path.Combine(directoryName, newName);
                File.Move(path, newPath);
            }
        }

        static void RenameFolder(string path)
        {
            string oldName = Path.GetDirectoryName(path);
            string newName = ConvertCyrillicToLatin(oldName);

            Directory.CreateDirectory(newName);

            if (oldName != newName)
            {
                var newPath = Path.Combine(oldName, newName);
                File.Move(path, newPath);
            }
        }

        static string ConvertCyrillicToLatin(string input)
        {
            var result = new StringBuilder();

            foreach (var converted in input.Select(ConvertLetter))
            {
                result.Append(converted);
            }

            return result.ToString();
        }

        static string ConvertLetter(char c)
        {
            return c switch
            {
                'а' => "a",
                'б' => "b",
                'в' => "v",
                'г' => "g",
                'д' => "d",
                'е' => "e",
                'ё' => "yo",
                'ж' => "zh",
                'з' => "z",
                'и' => "i",
                'й' => "y",
                'к' => "k",
                'л' => "l",
                'м' => "m",
                'н' => "n",
                'о' => "o",
                'п' => "p",
                'р' => "r",
                'с' => "s",
                'т' => "t",
                'у' => "u",
                'ф' => "f",
                'х' => "kh",
                'ц' => "ts",
                'ч' => "ch",
                'ш' => "sh",
                'щ' => "sch",
                'ъ' => "",
                'ы' => "i",
                'ь' => "",
                'э' => "e",
                'ю' => "u",
                'я' => "ya",

                'А' => "A",
                'Б' => "B",
                'В' => "V",
                'Г' => "G",
                'Д' => "D",
                'Е' => "E",
                'Ё' => "E",
                'Ж' => "ZH",
                'З' => "Z",
                'И' => "I",
                'Й' => "Y",
                'К' => "K",
                'Л' => "L",
                'М' => "M",
                'Н' => "N",
                'О' => "O",
                'П' => "P",
                'Р' => "R",
                'С' => "S",
                'Т' => "T",
                'У' => "U",
                'Ф' => "F",
                'Х' => "KH",
                'Ц' => "TS",
                'Ч' => "CH",
                'Ш' => "SH",
                'Щ' => "SCH",
                'Ъ' => "",
                'Ы' => "I",
                'Ь' => "",
                'Э' => "E",
                'Ю' => "U",
                'Я' => "YA",

                _ => c.ToString()
            };
        }
    }
}