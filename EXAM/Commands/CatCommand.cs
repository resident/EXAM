using System;
using System.IO;

namespace EXAM.Commands
{
    public class CatCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Print file");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: cat <file path>");
        }
        
        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(1);

            var path = args[0];

            if (File.Exists(path))
                using (var sr = new FileInfo(path).OpenText())
                    while (!sr.EndOfStream)
                        Console.WriteLine(sr.ReadLine());
            else
                throw new FileNotFoundException();
        }
    }
}