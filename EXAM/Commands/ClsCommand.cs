using System;

namespace EXAM.Commands
{
    public class ClsCommand:Command
    {
        public override void HelpShort()
        {
            Console.WriteLine("Clear console");
        }

        public override void Help()
        {
            HelpShort();
            Console.WriteLine("Usage: cls");
        }
        
        public override void Run(Arguments args)
        {
            Console.Clear();
        }
    }
}