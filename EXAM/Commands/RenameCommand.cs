using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EXAM.Commands
{
    public class RenameCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Rename files and directories by regex pattern");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Command solves name conflicts by adding the suffix (n) to the file name");
            Console.WriteLine("Usage: rename [<directory path>] <source files regex pattern> <replacement>");
            Console.WriteLine();
            Console.WriteLine("Substitutions in Regular Expressions");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("| Substitution | Description                                                    |");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("|              | Includes the last substring matched by the capturing group     |");
            Console.WriteLine("| $ number     | that is identified by number, where number is a decimal value, |");
            Console.WriteLine("|              | in the replacement string.                                     |");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("| ${ name }    | Includes the last substring matched by the named group         |");
            Console.WriteLine("|              | that is designated by (?<name> ) in the replacement string.    |");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("| $&           | Includes a copy of the entire match in the replacement string. |");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("| $`           | Includes all the text of the input string before the match     |");
            Console.WriteLine("|              | in the replacement string.                                     |");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("| $'           | Includes all the text of the input string after the match      |");
            Console.WriteLine("|              | in the replacement string.                                     |");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("| $+           | Includes the last group captured in the replacement string.    |");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("| $_           | Includes the entire input string in the replacement string.    |");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
        }

        private static FileInfo ResolveConflict(FileSystemInfo file, DirectoryInfo directory)
        {
            var fileNameWithoutExtension = Regex.Replace(file.Name, @"(\(\d+\))?\..+$", "");
            var regex = Regex.Escape(fileNameWithoutExtension) + @"\((\d+)\)\..+$";

            var numbers = (from fileInfo in directory.EnumerateFiles()
                select Regex.Match(fileInfo.Name, regex) into m
                where m.Success
                select int.Parse(m.Groups[1].ToString())).ToList();

            var counter =  numbers.Count > 0 ? numbers.Max() + 1 : 1;
            var newFileName = $"{fileNameWithoutExtension}({counter}){file.Extension}";
            
            return new FileInfo(Path.Combine(directory.FullName, newFileName));
        }

        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(2);

            var path = args.Count == 3 ? args[0] : Directory.GetCurrentDirectory();
            var directory = new DirectoryInfo(path);

            if (!directory.Exists)
                throw new DirectoryNotFoundException();
            
            var pattern = new Regex(args[args.Count - 2]);
            var replacement   = args[args.Count - 1];

            foreach (var file in directory.EnumerateFiles())
            {
                var newFile = new FileInfo(Path.Combine(directory.FullName,
                    pattern.Replace(file.Name, replacement)));
                
                if (file.Name == newFile.Name) continue;

                if (newFile.Exists || Directory.Exists(newFile.FullName))
                    newFile = ResolveConflict(newFile, directory);

                file.MoveTo(newFile.FullName);
            }
        }
    }
}