using System;
using System.IO;

namespace EXAM.Commands
{
    public class DelCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Delete file or directory");
            Console.WriteLine("Usage: del <path>");
        }
        
        public override void Run(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Invalid arguments");

            var path = args[1];

            if ( File.Exists(path) )
                new FileInfo(path).Delete();
            else if (Directory.Exists(path))
                new DirectoryInfo(path).Delete(true);
            else
                throw new ArgumentException("Path not found");
        }
    }
}