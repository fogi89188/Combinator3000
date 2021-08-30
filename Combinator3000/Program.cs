using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Combinator3000
{
    class Program
    {
        public static List<string> permutatedList = new List<string>();
        public static List<string> englishWordList = new List<string>();
        private static List<string> permute(String str, int l, int r)
        {
            if (l == r)
                permutatedList.Add(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
            return permutatedList;
        }
        public static String swap(String a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        // Driver Code
        public static void Main()
        {
            GatherRealWords(englishWordList);

            //intro
            Console.WriteLine("This program takes a string of characters");
            Console.WriteLine("and checks if any combination of those letters");
            Console.WriteLine("makes up a real word from the English language.");
            Console.WriteLine("");
            Console.WriteLine("Please write a string of characters.");
            string str = Console.ReadLine();
            permutatedList = permute(str, 0, str.Length - 1);
            Console.Clear();


            //check if real word
            int wordCount = 0;
            List<string> realWords = new List<string>();

            for (int i = 0; i < permutatedList.Count; i++)
            {
                if (CheckIfRealWord(permutatedList[i]) == true)
                {
                    var checkIfRepeats = false;
                    for (int item = 0; item < realWords.Count; item++)
                    {
                        if (permutatedList[i] == realWords[item])
                        {
                            checkIfRepeats = true;
                        }
                    }
                    if (checkIfRepeats == false)
                    {
                        wordCount++;
                        realWords.Add(permutatedList[i]);
                    }
                }
            }

            if (wordCount == 0)
            {
                Console.WriteLine($"The string \"{str}\" cannot form an english word.");
            }
            else
            {
                Console.WriteLine($"The string \"{str}\" can create the following words:");
                Console.WriteLine();
                for (int i = 0; i < realWords.Count; i++)
                {
                    Console.WriteLine(realWords[i]);
                }
                Console.WriteLine();
            }

            //prevent app from closing
            Console.WriteLine(" Press any key to continue . . .");
            Console.ReadKey();
        }

        private static void GatherRealWords(List<string> englishWordList)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\vikto\\Google Drive\\Programs and ZIP's\\Quality of Life Scripts\\ListOfAllEnglishWords.txt");

            foreach (string line in lines)
            {
                englishWordList.Add(line);
            }
        }

        private static bool CheckIfRealWord(string v)
        {
            for (int item = 0; item < englishWordList.Count; item++)
            {
                if (v == englishWordList[item])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
