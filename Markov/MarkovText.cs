using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov
{
    class MarkovText
    {
        List<string> baseText = new List<string>();
        List<Word> baseTextWords = new List<Word>();
        List<string> resultText = new List<string>();
        List<Word> startWordsHubo = new List<Word>();
        Word startWord=null;
        static Random random = new Random();
        public MarkovText()
        {
        }
        public MarkovText(string fileName):this()
        {
            ReadBaseText(fileName);
            AnalyzeText();
        }
        public void Run(int wordNum)
        {
            startWord = startWordsHubo[random.Next(startWordsHubo.Count())];
            resultText.Add(startWord.word);
            Word nextWord=startWord;
            for(int i = 0; i < wordNum - 1; i++)
            {
                string nextWordString = nextWord.getRandomNextWord();
                if (nextWordString == "몰라")
                {
                    nextWordString = startWordsHubo[random.Next(startWordsHubo.Count())].word;
                }
                nextWord = StringToWord(nextWordString);
                resultText.Add(nextWord.word);
            }
            PrintText(resultText);
        }
        private void ReadBaseText(string fileName)
        {
            System.IO.StreamReader textFile = new System.IO.StreamReader(fileName);
            string line;
            while ((line = textFile.ReadLine()) != null)
            {
                foreach(string word in TextLineParsing(line))
                {
                    baseText.Add(word);
                }
            }
            textFile.Close();
        }
        private void AnalyzeText()
        {
            bool alreadySaved;
            Word tempWord=null;
            Word previousWord = null;
            foreach(string word in baseText)
            {
                alreadySaved=false;
                foreach(Word word2 in baseTextWords)
                {
                    if (word2.isSameWord(word))
                    {
                        alreadySaved = true;
                        tempWord = word2;
                        break;
                    }
                }
                if (alreadySaved)
                {
                    tempWord.numPlus();
                    if (previousWord != null)
                        previousWord.addFollowingWord(tempWord);
                    previousWord = tempWord;
                }
                else
                {
                    Word newWord = new Word(word);
                    baseTextWords.Add(newWord);
                    if (previousWord != null)
                        previousWord.addFollowingWord(newWord);
                    previousWord = newWord;
                }
            }
            int maxFrequency=0;
            foreach(Word word in baseTextWords)
            {
                if (word.num > maxFrequency)
                {
                    maxFrequency = word.num;
                }
            }
            foreach(Word word in baseTextWords)
            {
                if (word.num == maxFrequency)
                {
                    startWordsHubo.Add(word);
                }
            }
        }
        public Word StringToWord(string word)
        {
            foreach(Word word2 in baseTextWords)
            {
                if (word2.isSameWord(word))
                    return word2;
            }
            return null;
        }
        private void PrintText(List<string> text)
        {
            foreach(string word in text)
            {
                Console.Write(word+" ");
            }
            Console.WriteLine();
        }
        public static List<string> TextLineParsing(string line)
        {
            return line.Split(new char[] { ' ', '.', '?','!','-',';',':','"',',','(',')' },StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
