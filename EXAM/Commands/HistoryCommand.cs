using System;
using System.Collections.Generic;

namespace EXAM.Commands
{
    public class HistoryCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Print last used commands");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Default: 5 last commands");
            Console.WriteLine("Usages:");
            Console.WriteLine("\t history [<max commands>]");
            Console.WriteLine("\t history clear");
            Console.WriteLine("\t history get-buffer-size");
            Console.WriteLine("\t history set-buffer-size <buffer size>");
        }

        public override void Run(Arguments args)
        {
            var history = new List<string>();
            
            switch (args.Count)
            {
                case 0:
                    history = CommandsHistory.GetHistory();
                    break;
                case 1:
                    if (int.TryParse(args[0], out var max))
                        history = CommandsHistory.GetHistory(max);
                    else switch (args[0])
                    {
                        case "clear":
                            CommandsHistory.Clear();
                            break;
                        case "get-buffer-size":
                            Console.WriteLine(CommandsHistory.GetMaxCmdHistory());
                            break;
                        default:
                            throw new ArgumentException("Invalid command arguments");
                    }
                    
                    break;
                case 2:
                    if (args[0] == "set-buffer-size")
                        CommandsHistory.SetMaxCmdHistory(int.Parse(args[1]));
                    else
                        throw new ArgumentException("Invalid command arguments");
                    
                    break;
                default:
                    throw new ArgumentException("Invalid command arguments");
            }
            
            if(history.Count > 0)
                foreach (var item in history)
                    Console.WriteLine(item);
        }
    }
}