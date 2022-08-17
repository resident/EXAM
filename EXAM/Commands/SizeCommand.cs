using System;
using System.IO;
using System.Linq;

namespace EXAM.Commands
{
    public class SizeCommand:Command
    {
        private static long GetDirSize(DirectoryInfo di)
        {
            return di.EnumerateDirectories().Sum(GetDirSize) +
                di.EnumerateFiles().Sum(file => file.Length);
        }
        
        public override void Help()
        {
            Console.WriteLine("Print size file or directory");
            Console.WriteLine("Usage: size <path>");
        }
        
        public override void Run(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Invalid arguments");

            var path = args[1];
            
            if (Directory.Exists(path))
                Console.WriteLine($"{GetDirSize(new DirectoryInfo(path))} bytes");
            else if (File.Exists(path))
                Console.WriteLine($"{new FileInfo(path).Length} bytes");
            else
                throw new ArgumentException("Path not found");
        }
    }
}