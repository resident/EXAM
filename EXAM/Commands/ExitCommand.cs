using System;

namespace EXAM.Commands
{
    public class ExitCommand:Command
    {
        public int ExitCode { get; }

        public ExitCommand()
        {
        }

        public ExitCommand(int exitCode)
        {
            ExitCode = exitCode;
        }

        public override void HelpShort()
        {
            Console.WriteLine("Exit from program");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: exit");
        }

        public override void Run(Arguments args)
        {
            Console.WriteLine("Good bay!");
            Environment.Exit(ExitCode);
        }
    }
}