using System;
using System.IO;

namespace EXAM.Commands
{
    public class MoveCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Move file or directory");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: move <from path> <to path>");
        }
        
        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(2);
            
            var src = args[0];
            var dst = args[1];
            
            Directory.Move(src, dst);
        }
    }
}