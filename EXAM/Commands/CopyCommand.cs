using System;
using System.IO;

namespace EXAM.Commands
{
    public class CopyCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Copy file or directory");
        }

        public override void Help()
        {
            HelpShort();
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
        
        public override void Run(Arguments args)
        {
            args.ThrowIfArgsLessThan(2);

            var source      = args[0];
            var destination = args[1];
            
            if (File.Exists(source))
                File.Copy(source, destination);
            else if (Directory.Exists(source))
                CopyDirectory(source, destination);
            else
                throw new ArgumentException("Source path not found");
        }
    }
}