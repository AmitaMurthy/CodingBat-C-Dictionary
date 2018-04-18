using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Dictionary_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        /// <summary>
        /// Given an array of strings, return a Dictionary<string, int> containing a key for every different string in the array, always with the value 0. For example the string "hello" makes the pair "hello":0. We'll do more complicated counting later, but for this problem the value is simply 0.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static Dictionary<string, int> Word0(string[] strings)
        {
            var dict = new Dictionary<string, int>();

            foreach (string i in strings)
            {
                dict[i] = 0;
            }

            return dict;
        }

        /// <summary>
        /// Given an array of strings, return a Dictionary<string, int> containing a key for every different string in the array, and the value is that string's length.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static Dictionary<string, int> WordLen(string[] strings)
        {
            var dict = new Dictionary<string, int>();

            foreach (string i in strings)
            {
                dict[i] = i.Length;
            }

            return dict;
        }

        /// <summary>
        /// Given an array of non-empty strings, create and return a Dictionary<string, string> as follows: for each string add its first character as a key with its last character as the value.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Pairs(string[] strings)
        {
            var dict = new Dictionary<string, string>();

            foreach (string i in strings)
            {
                dict[i[0].ToString()] = i[i.Length - 1].ToString();
            }

            return dict;
        }

        /// <summary>
        /// The classic word-count algorithm: given an array of strings, return a Dictionary<string, int> with a key for each different string, with the value the number of times that string appears in the array.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static Dictionary<string, int> WordCount(string[] strings)
        {
            var dict = new Dictionary<string, int>();

            foreach (string i in strings)
            {
                int count = 0;
                foreach (string j in strings)
                {
                    if (i == j)
                    {
                        count++;
                    }
                }
                dict[i] = count;
            }

            return dict;
        }

        /// <summary>
        /// Given an array of non-empty strings, return a Dictionary<string, string> with a key for every different first character seen, with the value of all the strings starting with that character appended together in the order they appear in the array.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static Dictionary<string, string> FirstChar(string[] strings)
        {
            var dict = new Dictionary<string, string>();

            foreach (string i in strings)
            {
                if (dict.ContainsKey(i[0].ToString().ToUpper()))
                {
                    dict[i[0].ToString().ToUpper()] = dict[i[0].ToString()] + i;
                }
                else
                {
                    dict[i[0].ToString().ToUpper()] = i;
                }
            }

            return dict;
        }

        /// <summary>
        /// Loop over the given array of strings to build a result string like this: when a string appears the 2nd, 4th, 6th, etc. time in the array, append the string to the result. Return the empty string if no string appears a 2nd time.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static string WordAppend(string[] strings)
        {
            string result = "";
            var dict = new Dictionary<string, int>();
            foreach (string i in strings)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i]++;

                    result = dict[i] % 2 == 0 ? result + i : result;
                }
                else
                {
                    dict[i] = 1;
                }
            }

            return result;
        }

        /// <summary>
        /// Given an array of strings, return a Dictionary<String, bool> where each different string is a key and its value is true if that string appears 2 or more times in the array.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static Dictionary<string, bool> WordMultiple(string[] strings)
        {
            var dict = new Dictionary<string, bool>();

            foreach (string i in strings)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i] = true;
                }
                else
                {
                    dict[i] = false;
                }
            }


            return dict;
        }

        /// <summary>
        /// We'll say that 2 strings "match" if they are non-empty and their first chars are the same. Loop over and then return the given array of non-empty strings as follows: if a string matches an earlier string in the array, swap the 2 strings in the array. When a position in the array has been swapped, it no longer matches anything. Using a Dictionary, this can be solved making just one pass over the array. More difficult than it looks.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static string[] AllSwap(string[] strings)
        {
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < strings.Length; i++)
            {
                if (dict.ContainsKey(strings[i][0].ToString()))
                {
                    if (dict[strings[i][0].ToString()] >= 0)
                    {
                        string temp = strings[i];
                        strings[i] = strings[dict[strings[i][0].ToString()]];
                        strings[dict[strings[i][0].ToString()]] = temp;
                        dict[strings[i][0].ToString()] = -1;
                    }
                    else
                    {
                        dict[strings[i][0].ToString()] = i;
                    }
                }
                else
                {
                    dict[strings[i][0].ToString()] = i;
                }
            }

            return strings;
        }

        /// <summary>
        /// We'll say that 2 strings "match" if they are non-empty and their first chars are the same. Loop over and then return the given array of non-empty strings as follows: if a string matches an earlier string in the array, swap the 2 strings in the array. A particular first char can only cause 1 swap, so once a char has caused a swap, its later swaps are disabled. Using a Dictionary, this can be solved making just one pass over the array. More difficult than it looks.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static string[] FirstSwap(string[] strings)
        {
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < strings.Length; i++)
            {
                if (dict.ContainsKey(strings[i][0].ToString()))
                {
                    if (dict[strings[i][0].ToString()] >= 0)
                    {
                        string temp = strings[i];
                        strings[i] = strings[dict[strings[i][0].ToString()]];
                        strings[dict[strings[i][0].ToString()]] = temp;
                        dict[strings[i][0].ToString()] = -1;
                    }

                }
                else
                {
                    dict[strings[i][0].ToString()] = i;
                }
            }

            return strings;
        }
    }
}
