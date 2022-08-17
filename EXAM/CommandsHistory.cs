using System;
using System.Collections.Generic;

namespace EXAM
{
    public static class CommandsHistory
    {
        private static int _maxCmdHistory = 10;
        private static readonly List<string> History = new List<string>();

        public static void Save(string cmd)
        {
            if (History.Count == _maxCmdHistory)
                History.RemoveAt(0);
            
            History.Add(cmd);
        }

        public static int GetMaxCmdHistory() => _maxCmdHistory;
        
        public static void SetMaxCmdHistory(int max)
        {
            if (max < 1)
                throw new ArgumentException("max must be greater than 0");
            
            if (max < History.Count)
                History.RemoveRange(0, History.Count - max);

            _maxCmdHistory = max;
        }

        public static void Clear() => History.Clear();

        public static List<string> GetHistory(int max = 5)
        {
            if (max < 1)
                throw new ArgumentException("max must be greater than 0");
            
            var index = History.Count > max ? History.Count - max : 0;
            var count = History.Count > max ? max : History.Count;
            
            var tmp =  History.GetRange(index, count);
            
            return tmp;
        }
    }
}