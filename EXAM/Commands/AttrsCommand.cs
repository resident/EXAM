using System;
using System.IO;

namespace EXAM.Commands
{
    public class AttrsCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Print file attributes");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: attrs <file path>");
        }
        
        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(1);

            var path = args[0];

            if (File.Exists(path))
                Console.WriteLine(new FileInfo(path).Attributes);
            else if (Directory.Exists(path))
                Console.WriteLine(new DirectoryInfo(path).Attributes);
            else
                throw new FileNotFoundException();
        }
    }
}