using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace EXAM.Commands
{
    public class FindCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Recursive find files and directories using regular expressions");
            Console.WriteLine("Usage: find <directory path> <regex pattern>");
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
        
        public override void Run(string[] args)
        {
            if (args.Length != 3)
                throw new ArgumentException("Invalid arguments");

            var directory = new DirectoryInfo(args[1]);
            var pattern = new Regex(args[2]);

            if (!directory.Exists)
                throw new DirectoryNotFoundException();
                
            foreach (var path in Find(directory, pattern))
                Console.WriteLine(path);
                
        }
    }
}