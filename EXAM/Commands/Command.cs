using System;

namespace EXAM.Commands
{
    public abstract class Command
    {
        public abstract void Help();
        
        public abstract void Run(string[] args);
    }
}