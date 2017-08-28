using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Snowden
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\w)\1";
            string input = ReadFile();
            string output = input;

            var matches = Regex.Matches(input, pattern);
            while (matches.Count > 0)
            {
                output = Regex.Replace(output, pattern, String.Empty);
                Console.WriteLine("Decoding...");
                Console.WriteLine(output);
                matches = Regex.Matches(output, pattern);
            }
            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        public static string ReadFile()
        {
            Console.WriteLine("Enter file path:\n");
            var filePath = Console.ReadLine();
            string result = string.Empty;
            try
            {
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    result = File.ReadAllText(filePath);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find file.");
                result = ReadFile();
            }
            return result;
        }
    }
}
