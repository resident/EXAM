using System;
using System.IO;

namespace EXAM.Commands
{
    public class MoveCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Move file or directory");
            Console.WriteLine("Usage: move <from path> <to path>");
        }
        
        public override void Run(string[] args)
        {
            if (args.Length != 3)
                throw new ArgumentException("Invalid arguments");
            
            var src = args[1];
            var dst = args[2];
            
            Directory.Move(src, dst);
        }
    }
}