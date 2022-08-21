using System;
using System.IO;

namespace EXAM.Commands
{
    public class DelCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Delete file or directory");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: del <path>");
        }
        
        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(1);

            var path = args[0];

            if ( File.Exists(path) )
                new FileInfo(path).Delete();
            else if (Directory.Exists(path))
                new DirectoryInfo(path).Delete(true);
            else
                throw new ArgumentException("Path not found");
        }
    }
}