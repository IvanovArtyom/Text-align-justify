using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace Solution
{
    public class Kata
    {
        public static void Main()
        {
            // Test
            var t = Justify("Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Vestibulum sagittis dolor mauris, at elementum ligula tempor eget.", 30);
            // ...should return "Lorem  ipsum  dolor  sit amet,\n
            //                   consectetur  adipiscing  elit.\n
            //                   Vestibulum    sagittis   dolor\n
            //                   mauris,  at  elementum  ligula\n
            //                   tempor eget."
        }

        public static string Justify(string str, int len)
        {
            if (str == null)
                return string.Empty;

            string[] words = str.Split();
            List<List<string>> lines = new() { new List<string>() };
            int index = 0;

            foreach (string word in words)
            {
                if (lines[index].Count == 0 || lines[index].Select(s => s.Length).Sum() +
                    lines[index].Count + word.Length <= len)
                    lines[index].Add(word);

                else
                {
                    lines.Add(new List<string>());
                    lines[++index].Add(word);
                }
            }

            StringBuilder justifiedString = new();

            for (int i = 0; i < lines.Count - 1; i++)
            {
                justifiedString.Append(AddSpaces(lines[i], len));
                justifiedString.Append('\n');
            }

            justifiedString.Append(string.Join(' ', lines[^1]));

            return justifiedString.ToString();
        }

        public static string AddSpaces(List<string> line, int length)
        {
            if (line.Count == 1)
                return line[0];

            StringBuilder resultLine = new(line[0]);
            int curLength = line.Select(s => s.Length).Sum();
            double breaksCnt = line.Count - 1;
            int index = 1;

            while (breaksCnt != 0)
            {
                int value = (int)Math.Ceiling((length - curLength) / breaksCnt--);
                curLength += value;
                resultLine.Append(' ', value);
                resultLine.Append(line[index++]);
            }

            return resultLine.ToString();
        }
    }
}