using System;
using System.IO;

namespace EXAM.Commands
{
    public class MkdirCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Create new directory");
            Console.WriteLine("Usage: mkdir <directory name>");
        }
        
        public override void Run(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Invalid arguments");

            Directory.CreateDirectory(args[1]);
        }
    }
}