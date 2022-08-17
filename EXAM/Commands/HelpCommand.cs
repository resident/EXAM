using System;

namespace EXAM.Commands
{
    public class HelpCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Print commands list with description");
            Console.WriteLine("Usage: help [<command name>]");
        }

        private static void Help(string name)
        {
            CommandsProvider.GetCommand(name).Help();
        }
        
        public override void Run(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    Console.WriteLine("help   - Print this help or help for command");
                    Console.WriteLine("exit   - Exit from program");
                    Console.WriteLine("cls    - Clear console");
                    Console.WriteLine("touch  - Create empty file");
                    Console.WriteLine("attrs  - Print file attributes");
                    Console.WriteLine("cat    - Print file");
                    Console.WriteLine("dir    - List files");
                    Console.WriteLine("cd     - Change current directory");
                    Console.WriteLine("move   - Move file or directory");
                    Console.WriteLine("rename - Rename files or directories");
                    Console.WriteLine("copy   - Copy files");
                    Console.WriteLine("del    - Delete files");
                    Console.WriteLine("mkdir  - Create directory");
                    Console.WriteLine("find   - Recursive find files and directories using regular expressions");
                    Console.WriteLine("size   - Print size file or directory");
                    
                    break;
                case 2:
                    var cmdName = args[1];
                    
                    if (CommandsProvider.HasCommand(cmdName))
                        Help(cmdName);
                    else
                        throw new ArgumentException($"Command '{cmdName}' not found");
                    
                    break;
                default:
                    throw new ArgumentException("Invalid command arguments");
            }
        }
    }
}