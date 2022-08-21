using System;
using System.IO;

namespace EXAM
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CommandsProvider.InitCommands();

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine();
                Colorize.WrapCommandResult(()=>CommandsProvider.Run(new Arguments("exit")));
            };

            while (true)
            {
                var curDir = new DirectoryInfo(Directory.GetCurrentDirectory());
                
                Colorize.Wrap(()=>Console.Write($"{curDir}"), ConsoleColor.DarkCyan);
                Colorize.Wrap(()=>Console.Write(">"), ConsoleColor.DarkYellow);

                var cmd = string.Empty;
                
                Colorize.WrapCommand(() => {cmd = Console.ReadLine();});

                if (string.IsNullOrWhiteSpace(cmd)) continue;

                try
                {
                    var cmdArgs = new Arguments(cmd);

                    Colorize.WrapCommandResult(() => CommandsProvider.Run(cmdArgs));
                }
                catch (Exception e)
                {
                    Colorize.WrapException(() => Console.WriteLine(e.Message));   
                }
                finally
                {
                    CommandsHistory.Save(cmd);
                }
            }
        }
    }
}