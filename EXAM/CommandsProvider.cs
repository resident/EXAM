using System;
using System.Collections.Generic;
using EXAM.Commands;

namespace EXAM
{
    public static class CommandsProvider
    {
        private static Dictionary<string, Command> _commands = new Dictionary<string, Command>();

        public static void SetCommands(Dictionary<string, Command> commands)
        {
            _commands = commands;
        }
        
        public static void Add(string name, Command command)
        {
            _commands.Add(name, command);
        }
        
        public static void Remove(string name)
        {
            _commands.Remove(name);
        }

        public static bool HasCommand(string name)
        {
            return _commands.ContainsKey(name);
        }

        public static Command GetCommand(string name)
        {
            return HasCommand(name) ? _commands[name] : null;
        }

        public static void Run(string name, string[] args)
        {
            if (HasCommand(name))
                GetCommand(name).Run(args);
            else
                throw new ArgumentException("Command not found");
        }
    }
}