using System;

namespace EXAM.Commands
{
    public class ClsCommand:Command
    {
        public override void Help()
        {
            Console.WriteLine("Clear console");
            Console.WriteLine("Usage: cls");
        }
        
        public override void Run(string[] args)
        {
            Console.Clear();
        }
    }
}