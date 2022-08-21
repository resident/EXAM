using System;
using System.Collections.Generic;
using System.Linq;
using EXAM.Commands;

namespace EXAM
{
    public static class CommandsProvider
    {
        public static Dictionary<string, Command> Commands { get; set; } = new Dictionary<string, Command>();

        public static void InitCommands()
        {
            var types = typeof(Command).Assembly.GetTypes().Where(t => t.BaseType == typeof(Command));

            Commands.Clear();
            
            foreach (var type in types)
            {
                var info = type.GetConstructor(Type.EmptyTypes);

                if (info == null) continue;
                
                var command = (Command) info.Invoke(null);

                Commands.Add(type.Name.Replace("Command", "").ToLower(), command);
            }
        }

        public static void Add(string name, Command command)
        {
            Commands.Add(name, command);
        }
        
        public static void Remove(string name)
        {
            Commands.Remove(name);
        }

        public static bool HasCommand(string name)
        {
            return Commands.ContainsKey(name);
        }

        public static Command GetCommand(string name)
        {
            return HasCommand(name) ? Commands[name] : null;
        }

        public static Dictionary<string, Command>.KeyCollection GetCommandNames() => Commands.Keys;

        public static void Run(Arguments args)
        {
            if (HasCommand(args.CommandName))
                GetCommand(args.CommandName).Run(args);
            else
                throw new ArgumentException("Command not found");
        }
    }
}