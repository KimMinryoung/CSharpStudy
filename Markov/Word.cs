using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov
{
    class Word
    {
        static Random random = new Random();
        public string word;
        List<Word> followingWords=new List<Word>();
        public int num;
        private Word word1;

        public Word(string word)
        {
            this.word = word;
            num = 1;
        }

        public Word(Word word1)
        {
            this.word1 = word1;
        }

        public void numPlus()
        {
            num++;
        }
        public bool isSameWord(string word)
        {
            return this.word == word;
        }
        public bool isSameWord(Word word)
        {
            return this.word == word.word;
        }
        public void addFollowingWord(Word word)
        {
            bool alreadySaved = false;
            Word tempWord = null;
            foreach (Word word2 in followingWords)
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
            }
            else
            {
                followingWords.Add(new Word(word.word));
            }
        }
        public string getRandomNextWord()
        {
            int followingWordDataNum = 0;
            foreach (Word followingWord in followingWords)
            {
                followingWordDataNum += followingWord.num;
            }
            if (followingWordDataNum == 0)
                return "몰라";
            else
            {
                int randomNum = random.Next(followingWordDataNum);
                int count = 0;
                foreach (Word followingWord in followingWords)
                {
                    count += followingWord.num;
                    if (count > randomNum)
                        return followingWord.word;
                }
                return "오류";
            }
        }
    }
}
