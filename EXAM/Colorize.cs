using System;

namespace EXAM
{
    public class Colorize
    {
        public static ConsoleColor ForegroundOriginal { get; } = Console.ForegroundColor;
        
        public static ConsoleColor BackgroundOriginal { get; } = Console.BackgroundColor;
        
        public static ConsoleColor CommandColor { get; set; } = ConsoleColor.DarkBlue;
        
        public static ConsoleColor CommandResultColor { get; set; } = ConsoleColor.Green;
        
        public static ConsoleColor ExceptionColor { get; set; } = ConsoleColor.Red;
        
        
        public static void Wrap(Action action, ConsoleColor? fColor = null, ConsoleColor? bColor = null)
        {
            if (fColor != null)
                Console.ForegroundColor = (ConsoleColor) fColor;

            if (bColor != null)
                Console.BackgroundColor = (ConsoleColor) bColor;

            action();
            
            Console.ForegroundColor = ForegroundOriginal;
            Console.BackgroundColor = BackgroundOriginal;
        }

        public static void WrapCommand(Action action) => Wrap(action, CommandColor);
        
        public static void WrapCommandResult(Action action) => Wrap(action, CommandResultColor);
        
        public static void WrapException(Action action) => Wrap(action, ExceptionColor);
    }
}