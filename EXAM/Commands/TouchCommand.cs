using System;
using System.IO;

namespace EXAM.Commands
{
    public class TouchCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Create new file");
            Console.WriteLine("Usage: touch <file path>");
        }
        
        public override void Run(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Invalid arguments");
            
            var path = args[1];

            if (File.Exists(path) || Directory.Exists(path))
                throw new ArgumentException("Path already exists");

            new FileInfo(path).CreateText().Dispose();
        }
    }
}