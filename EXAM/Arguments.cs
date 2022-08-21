using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EXAM
{
    public class Arguments
    {
        public string CommandFull { get; }
        public string CommandName { get; private set; }
        private List<string> Args { get; set; }
        public int Count => Args.Count;

        public string this[int pos] => Args[pos];

        public Arguments(string cmd)
        {
            CommandFull = cmd;
            ParseCmd();
        }

        private void ParseCmd()
        {
            Args = new Regex(" +(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")
                .Split(CommandFull)
                .Select(s => s.Replace("\"", ""))
                .ToList();

            if (Args.Count > 0)
            {
                CommandName = Args.First();
                Args.RemoveAt(0);
            }
        }

        public void ThrowIfArgsLessThan(uint count)
        {
            if (Args.Count < count)
                throw new ArgumentException($"Requires {count} arguments");
        }
    }
}