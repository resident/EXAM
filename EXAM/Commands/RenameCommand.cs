using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EXAM.Commands
{
    public class RenameCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Rename files and directories by regex pattern");
            Console.WriteLine("Usage: rename <directory path> <source files regex pattern> <replacement>");
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

        public override void Run(string[] args)
        {
            if (args.Length != 4)
                throw new ArgumentException("Invalid arguments");

            var directory = new DirectoryInfo(args[1]);

            if (!directory.Exists)
                throw new DirectoryNotFoundException();
            
            var pattern = new Regex(args[2]);
            var replacement   = args[3];

            foreach (var file in directory.EnumerateFiles())
            {
                var newFile = new FileInfo(Path.Combine(directory.FullName,
                    pattern.Replace(file.Name, replacement)));
                
                if (file.Name == newFile.Name) continue;

                if (newFile.Exists || Directory.Exists(newFile.FullName))
                    newFile = ResolveConflict(newFile, directory);

                Console.WriteLine($"Old: {file.Name} New: {newFile.Name}");
                file.MoveTo(newFile.FullName);
            }
        }
    }
}