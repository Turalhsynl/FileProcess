using System.Text;

class program
{
    public static void printMenu()
    {
        Console.WriteLine("1.Create folder");
        Console.WriteLine("2.Show directory");
        Console.WriteLine("3.Delete folder");
        Console.WriteLine("4.Create file");
        Console.WriteLine("5.Delete file");
        Console.WriteLine("6.Move file");
        Console.WriteLine("7.Search file");
        Console.WriteLine("8.Show all files");
    }

    public static void createFolder(string folderName)
    {
        Directory.CreateDirectory($"C:\\Users\\Husey_vw08\\Desktop\\{folderName}");
    }
    public static void deleteFolder(string delFolderName)
    {
        Directory.Delete($"C:\\Users\\Husey_vw08\\Desktop\\{delFolderName}");
    }
    public static void createFile(string str, string fileName)
    {
        using (FileStream fs = new FileStream($"{fileName}.txt", FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = Encoding.Default.GetBytes(str);
            fs.Write(buffer, 0, buffer.Length);
        }
    }

    public static void deleteFile(string fileName)
    {
        if (File.Exists($"{fileName}.txt"))
        {
            File.Delete($"{fileName}.txt");
            Console.WriteLine($"{fileName}.txt deleted.");
        }
        else
        {
            Console.WriteLine($"{fileName}.txt can't found.");
        }
    }

    public static void SearchFile(string fileName)
    {
        if (File.Exists($"{fileName}.txt"))
        {
            string fileContent = File.ReadAllText($"{fileName}.txt");
            Console.WriteLine($"Content of {fileName}.txt: {fileContent}");
        }
        else
        {
            Console.WriteLine($"{fileName}.txt not found.");
        }
    }

    public static void ShowAllFiles()
    {
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
        if (files.Length > 0)
        {
            Console.WriteLine("Text files in the current directory:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        else
        {
            Console.WriteLine("No text files found in the current directory.");
        }
    }

    public static void MoveFile(string fileName, string destFolder)
    {
        string sourceFile = $"{fileName}.txt";
        string destFile = Path.Combine(destFolder, $"{fileName}.txt");

        if (File.Exists(sourceFile))
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
            File.Move(sourceFile, destFile);
            Console.WriteLine($"{fileName}.txt moved to {destFolder}.");
        }
        else
        {
            Console.WriteLine($"{fileName}.txt not found.");
        }
    }

    static void Main(string[] args)
    {


        while (true)
        {
            printMenu();
            Console.WriteLine("Enter the choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter folder name to create: ");
                        string folderName = Console.ReadLine();
                        createFolder(folderName);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(Directory.GetCurrentDirectory());
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter folder name to delete: ");
                        string folderName = Console.ReadLine();
                        deleteFolder(folderName);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Enter file name: ");
                        string filename = Console.ReadLine();
                        Console.WriteLine("Enter luboy text: ");
                        string str = Console.ReadLine();
                        createFile(str, filename);
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Enter file name: ");
                        string fileName = Console.ReadLine();
                        deleteFile(fileName);
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Enter file name: ");
                        string fileName = Console.ReadLine();
                        Console.WriteLine("Enter destination folder: ");
                        string destfolder = Console.ReadLine();
                        MoveFile(fileName, destfolder);
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Enter file name to search: ");
                        string fileName = Console.ReadLine();
                        SearchFile(fileName);
                        break;
                    }
                case 8:
                    {
                        ShowAllFiles();
                        break;
                    }
            }
        }
    }
}