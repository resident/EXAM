using System;
using System.IO;

namespace EXAM.Commands
{
    public class MkdirCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Create new directory");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: mkdir <directory name>");
        }
        
        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(1);

            Directory.CreateDirectory(args[0]);
        }
    }
}