using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

    }

    public class Persistance
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }


    class SingleResponsibility
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var p = new Persistance();
            var filename = @"c:\work\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start("notepad.exe", filename);

        }
    }
}
