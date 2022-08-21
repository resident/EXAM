using System;

namespace EXAM.Commands
{
    public class HelpCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Print commands list with description");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: help [<command name>]");
        }

        private static void Help(string commandName)
        {
            if (CommandsProvider.HasCommand(commandName))
                CommandsProvider.GetCommand(commandName).Help();
            else
                throw new ArgumentException($"Command '{commandName}' not found");
        }
        
        public override void Run(Arguments args)
        {
            switch (args.Count)
            {
                case 0:
                    foreach (var command in CommandsProvider.Commands)
                    {
                        Console.Write($"{command.Key, -10} - ");
                        command.Value.HelpShort();
                    }
                    
                    break;
                case 1:
                    Help(args[0]);
                    break;
                default:
                    throw new ArgumentException("Invalid command arguments");
            }
        }
    }
}