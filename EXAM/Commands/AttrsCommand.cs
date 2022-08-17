using System;
using System.IO;

namespace EXAM.Commands
{
    public class AttrsCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Print file attributes");
            Console.WriteLine("Usage: attrs <file path>");
        }
        
        public override void Run(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Invalid arguments");

            var path = args[1];

            if (File.Exists(path))
            {
                var attrs = new FileInfo(path).Attributes;

                Console.WriteLine(attrs);
            }
            else
                throw new FileNotFoundException();
        }
    }
}