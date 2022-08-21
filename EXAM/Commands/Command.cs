namespace EXAM.Commands
{
    public abstract class Command
    {
        public abstract void HelpShort();
        
        public abstract void Help();
        
        public abstract void Run(Arguments args);
    }
}