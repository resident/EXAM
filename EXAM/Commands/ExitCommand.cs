using System;

namespace EXAM.Commands
{
    public class ExitCommand:Command
    {
        public int ExitCode { get; set; } = 0;

        public override void Help()
        {
            Console.WriteLine("Exit from program");
            Console.WriteLine("Usage: exit");
        }

        public override void Run(string[] args)
        {
            Console.WriteLine("Good bay!");
            Environment.Exit(ExitCode);
        }
    }
}