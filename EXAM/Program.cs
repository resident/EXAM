using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using EXAM.Commands;

namespace EXAM
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CommandsProvider.SetCommands(new Dictionary<string, Command>
            {
                {"help", new HelpCommand()},
                {"exit", new ExitCommand()},
                {"history", new HistoryCommand()},
                {"cls", new ClsCommand()},
                {"touch", new TouchCommand()},
                {"attrs", new AttrsCommand()},
                {"cat", new CatCommand()},
                {"dir", new DirCommand()},
                {"cd", new CdCommand()},
                {"move", new MoveCommand()},
                {"rename", new RenameCommand()},
                {"copy", new CopyCommand()},
                {"del", new DelCommand()},
                {"mkdir", new MkdirCommand()},
                {"find", new FindCommand()},
                {"size", new SizeCommand()},
            });

            while (true)
            {
                var curDir = new DirectoryInfo(Directory.GetCurrentDirectory());
                
                Console.Write($"{curDir}>");
                var cmd = Console.ReadLine();

                if (string.IsNullOrEmpty(cmd))
                    continue;

                try
                {
                    var cmdArgs = new Regex(" +(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")
                        .Split(cmd)
                        .Select(s => s.Replace("\"", ""))
                        .ToArray();

                    CommandsProvider.Run(cmdArgs.First(), cmdArgs);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    CommandsHistory.Save(cmd);
                }
            }
        }
    }
}