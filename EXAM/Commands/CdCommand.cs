using System;
using System.IO;

namespace EXAM.Commands
{
    public class CdCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Change current directory");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: cd <path>");
        }
        
        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(1);

            var path = args[0];

            if (Directory.Exists(path))
                Directory.SetCurrentDirectory(path);
            else
                throw new DirectoryNotFoundException();
        }
    }
}