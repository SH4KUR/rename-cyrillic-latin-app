using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter the path of the directory: ");
        var directoryPath = Console.ReadLine();

        if (Directory.Exists(directoryPath))
        {
            RenameFiles(directoryPath);
            RenameFolders(directoryPath);

            Console.WriteLine("Renaming completed successfully.");
        }
        else
        {
            Console.WriteLine("Directory not found.");
        }
    }
    
    private static void RenameFiles(string path) 
    {
        var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            RenameFile(file);
        }
    }

    private static void RenameFolders(string path) 
    {
        var folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

        foreach (var folder in folders)
        {
            RenameFolder(folder);
        }
    }

    private static void RenameFile(string path)
    {
        var directoryName = Path.GetDirectoryName(path) ?? throw new NullReferenceException();

        var oldName = Path.GetFileName(path);
        var newName = ConvertCyrillicToLatin(oldName);

        if (oldName != newName)
        {
            var newPath = Path.Combine(directoryName, newName);
            File.Move(path, newPath);
        }
    }

    private static void RenameFolder(string path)
    {
        var oldName = new DirectoryInfo(path).Name;
        var newName = ConvertCyrillicToLatin(oldName);

        if (oldName != newName)
        {
            var pathToFolder = Path.GetDirectoryName(path) ?? throw new NullReferenceException();
            var newPath = Path.Combine(pathToFolder, newName);

            Directory.Move(path, newPath);
        }
    }

    private static string ConvertCyrillicToLatin(string input)
    {
        var result = new StringBuilder();

        foreach (var converted in input.Select(ConvertLetter))
        {
            result.Append(converted);
        }

        return result.ToString();
    }

    private static string ConvertLetter(char c)
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
