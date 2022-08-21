using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace EXAM.Commands
{
    public class FindCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Recursive find files and directories using regular expressions");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: find <path> <regex pattern>");
        }

        private static List<string> Find(DirectoryInfo di, Regex pattern)
        {
            var result = new List<string>();
            
            foreach (var directory in di.EnumerateDirectories())
            {
                if ( pattern.IsMatch(directory.Name) )
                    result.Add(directory.FullName);
                
                result.AddRange(Find(directory, pattern));
            }

            result.AddRange(from file in di.EnumerateFiles() where pattern.IsMatch(file.Name) select file.FullName);

            return result;
        }
        
        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(2);

            var path = args[0];
            var pattern = new Regex(args[1]);

            if (File.Exists(path))
            {
                var file = new FileInfo(path);
                
                if (pattern.IsMatch(file.Name))
                    Console.WriteLine(file.FullName);
            }
            else if (Directory.Exists(path))
                foreach (var item in Find(new DirectoryInfo(path), pattern))
                    Console.WriteLine(item);
            else
                throw new ArgumentException($"Path '{path}' not found");
                
        }
    }
}