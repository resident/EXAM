using System;
using System.Collections.Generic;

namespace EXAM.Commands
{
    public class HistoryCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Print last used commands");
            Console.WriteLine("Usages:");
            Console.WriteLine("\t history [<max commands>]");
            Console.WriteLine("\t history clear");
            Console.WriteLine("\t history set-max <max-cmd-limit>");
        }

        public override void Run(string[] args)
        {
            var history = new List<string>();
            
            switch (args.Length)
            {
                case 1:
                    history = CommandsHistory.GetHistory();
                    break;
                case 2:
                    if (int.TryParse(args[1], out var max))
                        history = CommandsHistory.GetHistory(max);
                    else if (args[1] == "clear")
                        CommandsHistory.Clear();
                    else
                        throw new ArgumentException("Invalid command arguments");
                    
                    break;
                case 3:
                    if (args[1] == "set-max")
                        CommandsHistory.SetMaxCmdHistory(int.Parse(args[2]));
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