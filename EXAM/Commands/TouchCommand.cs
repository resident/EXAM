using System;
using System.IO;

namespace EXAM.Commands
{
    public class TouchCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Create new file");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: touch <file path>");
        }
        
        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(1);
            
            var path = args[0];

            if (File.Exists(path) || Directory.Exists(path))
                throw new ArgumentException("Path already exists");

            new FileInfo(path).CreateText().Dispose();
        }
    }
}