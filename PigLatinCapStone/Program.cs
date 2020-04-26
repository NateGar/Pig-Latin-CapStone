using System;

namespace PigLatinCapStone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tittle
            Console.WriteLine("Pig Latin Translator");
            bool loop = true;
            while (loop == true)
            {

                //Prompt user for input
                Console.WriteLine("Please enter a word you would like translated: ");
                //Store user input in a string and convert to lower case
                string userInput = Console.ReadLine().ToLower().Trim();
                
                //Take input string and covert it into an array
                char[] word = userInput.ToCharArray();

                //declare and initialize a variables to use in if statment
                string output = "";
                int firstVowelPlace = FirstVowel(word);
                //if statment to add "way" if position "0" returns true from Vowel method
                //or ignore words with no vowels
                //or find first vowel split word then const them back together in the order we want plus "ay"
                if (firstVowelPlace == 0)
                {
                    output = userInput + "way";
                }
                else if (firstVowelPlace == -1)
                {
                    output = userInput;
                }
                else
                {
                    string prefix = userInput.Substring(firstVowelPlace);
                    string postfix = userInput.Substring(0, firstVowelPlace) + "ay";
                    output = string.Concat(prefix, postfix);
                }
                Console.WriteLine(output);

                //set statment to true then create while loop to ask user to continue
                bool askAgain = true;
                while (askAgain == true)
                {
                    Console.WriteLine("Would you like to translate another word? y/n ");
                    string response = Console.ReadLine().ToLower().Trim();
                    if (response == "y")
                    {
                        loop = true;
                        askAgain = false;
                    }
                    else if (response == "n")
                    {
                        loop = false;
                        askAgain = false;
                    }
                }
            }
        }
        //Method to find if it has vowels in the word collected form the user
        public static bool Vowel(char c)
        {
            //list vowels in an array
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            //loop looking at each vowel indivdualy(keeping place values)
            foreach(char vowel in vowels)
            {
                //compare if each letter of the user word matches any of the vowels listed in array
                if(vowel == c)
                {
                    //returning a bool to satisfy method
                    return true;
                }
            }
            //returning a bool if statment above fails, to satisfy method
            return false;
        }
        //Method to find the placment of first vowel
        public static int FirstVowel(char[] word)
        {
            //for loop to look at each letter until it finds a vowel
            for(int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                //if statment to return the index of the first vowel
                if(Vowel(letter))
                {
                    return i;
                }
            }
            //tell user not a valid entry
            Console.WriteLine("No vowels found in " + word);
            return -1;

        }
    }
}
    
