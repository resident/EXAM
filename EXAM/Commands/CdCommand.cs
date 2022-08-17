using System;
using System.IO;

namespace EXAM.Commands
{
    public class CdCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Change current directory");
            Console.WriteLine("Usage: cd <path>");
        }
        
        public override void Run(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Invalid arguments");

            var path = args[1];

            if (Directory.Exists(path))
                Directory.SetCurrentDirectory(path);
            else
                throw new DirectoryNotFoundException();
        }
    }
}