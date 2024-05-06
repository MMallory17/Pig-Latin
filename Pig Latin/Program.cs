using System;

class PigLatinTranslator
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Pig Latin Translator!");

        string inputLine;
        bool continueTranslation = true;

        while (continueTranslation)
        {
            Console.Write("Enter a line to be translated: ");
            inputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Console.WriteLine("Invalid");
            }
            else
            {
                Console.WriteLine(TranslateToPigLatin(inputLine));
            }

            Console.Write("Translate another line? (y/n): ");
            continueTranslation = Console.ReadLine().Trim().ToLower() == "y";
        }
    }

    private static string TranslateToPigLatin(string text)
    {
        string[] words = text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = TranslateWord(words[i]);
        }
        return String.Join(" ", words);
    }

    private static string TranslateWord(string word)
    {
        int firstVowelIndex = FindFirstVowel(word);
        string translatedWord;

        if (firstVowelIndex == 0)
        {
            translatedWord = word + "way";
        }
        else if (firstVowelIndex > 0)
        {
            translatedWord = word.Substring(firstVowelIndex) + word.Substring(0, firstVowelIndex) + "ay";
        }
        else
        {
            translatedWord = word; // no vowels, return as is
        }

        return MaintainCase(word, translatedWord);
    }

    private static int FindFirstVowel(string word)
    {
        word = word.ToLower();
        string vowels = "aeiouy";

        for (int i = 0; i < word.Length; i++)
        {
            if (vowels.Contains(word[i]))
                return i;
        }

        return -1; // no vowels found
    }

    private static string MaintainCase(string original, string translated)
    {
        if (string.IsNullOrEmpty(original)) return translated;

        if (char.IsUpper(original[0]))
        {
            if (original.ToUpper() == original) // all uppercase
                return translated.ToUpper();
            else // title case
                return char.ToUpper(translated[0]) + translated.Substring(1).ToLower();
        }

        return translated.ToLower(); // default to lowercase
    }
}


