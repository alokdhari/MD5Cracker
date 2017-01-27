using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MD5Cracker
{
    public class Entry
    {
        private static List<Word> WordsList { get; set; }

        public static void Main()
        {
            Console.Write("!!");
            WordsList = new List<Word>();
            ReadFile();
            Thread.Sleep(5000);
        }

        public static void ReadFile()
        {
            var words = File.ReadAllText("../../wordlist");
            var wordList = words.Split(new[] {"\n"}, StringSplitOptions.None);
            var id = 1;
            var wordValue = 0;
            foreach(var word in wordList)
            {
                foreach(var character in word.ToCharArray())
                {
                    wordValue += character - 0;
                }

                WordsList.Add(new Word {Id = id, Name = word, Value = wordValue});
                wordValue = 0;
                id++;
            }
        }
    }

    public class Word
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }
    }
}