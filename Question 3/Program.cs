using MMGuide;

Anagram.IsAnagram_sort("blabla", "ballba");
Anagram.IsAnagram_sort("blabla", "bxlbal");
Anagram.IsAnagram_sort("debit card", "bad credit");
Anagram.IsAnagram_sort("Isaac Asimovs science fiction novel I robot", "A case of BIONIC love icons activities norms");
Anagram.IsAnagram_sort("I am Lord Voldemort", "Tom Marvolo Riddle");
Anagram.IsAnagram_sort("I am Lord Voldemort", "TDugWrNfFOCZX");
Anagram.IsAnagram_sort("I am Lord Voldemort", "iamlordvoldemort");

Console.WriteLine("");

Anagram.IsAnagram_search("blabla", "ballba");
Anagram.IsAnagram_search("blabla", "bxlbal");
Anagram.IsAnagram_search("debit card", "bad credit");
Anagram.IsAnagram_search("Isaac Asimovs science fiction novel I robot", "A case of BIONIC love icons activities norms");
Anagram.IsAnagram_search("I am Lord Voldemort", "Tom Marvolo Riddle");
Anagram.IsAnagram_search("I am Lord Voldemort", "TDugWrNfFOCZX");
Anagram.IsAnagram_search("I am Lord Voldemort", "iamlordvoldemort");


namespace MMGuide
{

    public class Anagram
    {


        /*

        To decide whether or not two strings are anagrams, this method first sorts the characters in both strings (after cleanup) and then 
        checks if the resulting strings are equal. 

        C#'s Array.Sort uses various sorting algorithms depending on the length of the strings. The space complexity varies from O(log n) 
        to O(n) depending on best/worst case or O(1) for small datasets, where n is the length of the string.

        The other operations are O(n), since we don't need more space than the strings themselves, resulting in overall O(n)
        space complexity.

        The time complexity of these sort algorithms is worst case O(n^2). The string compare operation is linear, resulting in 
        an overall time worst-case complexity of O(n^2), but average case O(log n).
         
        */

        public static void IsAnagram_sort(string word1, string word2)
        {
            var word1Clean = word1.Replace(" ", string.Empty).ToLower();
            var word2Clean = word2.Replace(" ", string.Empty).ToLower();

            if (Anagram.SortString(word1Clean).ToLower() == Anagram.SortString(word2Clean).ToLower())
            {
                Console.WriteLine($"The words '{word1}' and '{word2}' are anagrams.");
            }
            else
            {
                Console.WriteLine($"The words '{word1}' and '{word2}' are not anagrams.");
            }
        }

        /*
         
        This alternative method loops over the characters of string 1, searches for each in the string 2, and if found, replaces 
        with a space. If we end up with all spaces in string 2, the original strings are anagrams. 

        The space complexity os O(n), since we don't need more space than the arrays/strings. 

        The time complexity is O(n^2), since for each string we need to search another string of length n, resulting in O(n*n) operations.

        */


        public static void IsAnagram_search(string word1, string word2)
        {
            var word1Clean = word1.Replace(" ", string.Empty).ToLower();
            var word2Clean = word2.Replace(" ", string.Empty).ToLower();

            char[] resultArray = word2Clean.ToCharArray();

            int i = 0;
            var ErrorFound = false;
            while (i < word1Clean.Length && !ErrorFound)
            {
                var index = Array.IndexOf(resultArray, word1Clean[i]);

                if (index != -1)
                {
                    resultArray[index] = ' ';
                }
                else
                {
                    ErrorFound = true;
                }
                i++;
            }
            string resultString = new string(resultArray).Trim();

            if (resultString == "")
            {
                Console.WriteLine($"The words '{word1}' and '{word2}' are anagrams.");
            }
            else
            {
                Console.WriteLine($"The words '{word1}' and '{word2}' are not anagrams.");
            }


        }


        public static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }

}
