using System;
using System.IO;

namespace EXAM.Commands
{
    public class CatCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Print file");
            Console.WriteLine("Usage: cat <file path>");
        }
        
        public override void Run(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Invalid arguments");

            var path = args[1];

            if (File.Exists(path))
                using (var sr = new FileInfo(path).OpenText())
                    while (!sr.EndOfStream)
                        Console.WriteLine(sr.ReadLine());
            else
                throw new FileNotFoundException();
        }
    }
}