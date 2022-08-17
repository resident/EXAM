using System;
using System.IO;

namespace EXAM.Commands
{
    public class DirCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("List files");
            Console.WriteLine("Usage: dir [<path>]");
        }
        
        public override void Run(string[] args)
        {
            string path;
            
            switch (args.Length)
            {
                case 1:
                    path = Directory.GetCurrentDirectory();
                    break;
                case 2:
                    path = args[1];
                    break;
                default:
                    throw new ArgumentException("Invalid arguments");
            }

            Console.Write("LastWriteTime".PadRight(25));
            Console.Write("Length".PadRight(13));
            Console.WriteLine("Name");
            Console.WriteLine("".PadRight(50, '-'));

            if (File.Exists(path))
            {
                var file = new FileInfo(path);
                Console.WriteLine($"{file.LastWriteTime,-25}  {file.Length,-10} {file.Name}");
            }
            else if (Directory.Exists(path))
            {
                var di = new DirectoryInfo(path);

                foreach (var directory in di.EnumerateDirectories())
                    Console.WriteLine($"{directory.LastWriteTime,-25} {string.Empty,-11} {directory.Name}");

                foreach (var file in di.EnumerateFiles())
                    Console.WriteLine($"{file.LastWriteTime,-25}  {file.Length,-10} {file.Name}");
            }
            else
                throw new ArgumentException("Path not found");
        }
    }
}