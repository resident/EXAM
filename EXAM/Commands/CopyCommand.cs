using System;
using System.IO;

namespace EXAM.Commands
{
    public class CopyCommand:Command
    {
        public override void Help()
        {
            
            Console.WriteLine("Copy file or directory");
            Console.WriteLine("Usage: copy <source path> <destination path>");
        }
        
        private void CopyDirectory(string source, string destination)
        {
            Directory.CreateDirectory(destination);
            
            foreach (var file in Directory.GetFiles(source))
                File.Copy(file, Path.Combine(destination, Path.GetFileName(file)));

            foreach (var directory in Directory.GetDirectories(source))
                CopyDirectory(directory, Path.Combine(destination, Path.GetFileName(directory)));
        }
        
        public override void Run(string[] args)
        {
            if (args.Length != 3)
                throw new ArgumentException("Invalid arguments");

            var source      = args[1];
            var destination = args[2];
            
            if (File.Exists(source))
                if (!File.Exists(destination))
                    File.Copy(source, destination);
                else
                    throw new ArgumentException("Destination file already exists");
            else if (Directory.Exists(source))
                if (!Directory.Exists(destination))
                    CopyDirectory(source, destination);
                else
                    throw new ArgumentException("Destination directory already exists");
            else
                throw new ArgumentException("Source path not found");
        }
    }
}