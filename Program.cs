using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfValidWordsForEachPuzzle_11._9._21_CM
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            words.Add("apple");
            words.Add("pleas");
            words.Add("please");

            List<string> puzzles = new List<string>();
            puzzles.Add("aelwxyz");
            puzzles.Add("aelpxyz");
            puzzles.Add("aelpsxy");
            puzzles.Add("saelpxy");
            puzzles.Add("xaelpsy");

            IList<int> wordsFound = FindNumOfValidWords(words.ToArray(), puzzles.ToArray());


            if (wordsFound.Count == 0)
            {
                Console.WriteLine("No words found");
            }
            else
            {
                foreach (int wordFound in wordsFound)
                {
                    Console.WriteLine(wordFound);
                }
            }

            Console.ReadKey();
        }

        public static IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
        {
            List<int> validWordsFound = new List<int>();
            int count = 0;

            for (int i = 0; i <= words.Length - 1; i++)
                for (int j = 0; j <= puzzles.Length - 1; j++)
                    if (IsInSourceString(words[i], puzzles[j]))
                    {
                        validWordsFound.Add(count);
                        count++;
                    }


            return validWordsFound;
        }

        public static bool IsInSourceString(string source, string wordToFind)
        {
            if (source.Equals(wordToFind))
            {
                return true;
            }

            char[] tempSourceWord = source.ToCharArray();
            char[] tempWordToFind = wordToFind.ToCharArray();

            List<char> lettersFound = new List<char>();

            Array.Sort(tempSourceWord);
            Array.Sort(tempWordToFind);

            foreach (char letter in tempWordToFind)
            {
                for (int i = 0; i < tempSourceWord.Length; i++)
                {
                    char sourceLetter = tempSourceWord[i];
                    if (letter == sourceLetter)
                    {
                        lettersFound.Add(letter);
                        tempSourceWord[i] = '\0';
                        break;
                    }
                }
            }

            var wordFound = new string(lettersFound.ToArray());

            char[] sortedWordToFind = wordToFind.ToCharArray();

            Array.Sort(sortedWordToFind);

            var sortedWord = new string(sortedWordToFind.ToArray());

            if (wordFound == sortedWord)
            {
                return true;
            }

            return false;
        }
    }
}
