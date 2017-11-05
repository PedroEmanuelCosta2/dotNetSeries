using System;
using System.Collections.Generic;
using System.Linq;

namespace Serie03
{
    public class Word
    {
        //Arguments
        private String word;
        private String maskedWord;
        private int score;
        private int hashCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Serie03.Word"/> class.
        /// </summary>
        /// <param name="word">Word.</param>
        public Word(String word)
        {
            this.word = word;
            this.score = -1;
            this.hashCode = this.GetHashCode();
            this.maskedWord = String.Concat(Enumerable.Repeat("_", this.word.Length));
        }

        /// <summary>
        /// Gets the masked word.
        /// </summary>
        /// <returns>The masked word.</returns>
        public String getMaskedWord()
        {
            //Test if the word contains the char '-'
            if (this.word.Contains("-"))
            {
				List<char> maskedWordList = this.maskedWord.ToList();
                int indice = word.IndexOf("-", StringComparison.Ordinal);
                maskedWordList[indice] = '-';
                this.maskedWord = String.Join("", maskedWordList.ToArray());
            }

            return this.maskedWord;
        }

        /// <summary>
        /// Gets the word with the hint letters.
        /// </summary>
        /// <returns>The hint word.</returns>
        /// <param name="letters">Letters.</param>
        public String getHintWord(String letters)
        {
            List<char> maskedWordList = this.maskedWord.ToList();

            foreach (char charachter in letters)
            {
                if (word.IndexOf(charachter+"",StringComparison.OrdinalIgnoreCase)>= 0)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (String.Equals(word[i]+"",charachter+"",StringComparison.OrdinalIgnoreCase))
                        {
                            maskedWordList[i] = word[i];
                        }
                    }
                }
            }

            maskedWord = String.Join("", maskedWordList.ToArray());

            return this.maskedWord;
        }

        /// <summary>
        /// Resets the masked word.
        /// </summary>
        public void resetMaskedWord()
        {
            this.maskedWord = String.Concat(Enumerable.Repeat("_", this.word.Length));
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public int getHashCode()
        {
            return this.hashCode;
        }

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <returns>The score.</returns>
        public int getScore()
        {
            return this.score;
        }

        /// <summary>
        /// Sets the score.
        /// </summary>
        /// <param name="score">Score.</param>
        public void setScore(int score)
        {
            this.score = score;
        }

        /// <summary>
        /// Gets the word.
        /// </summary>
        /// <returns>The word.</returns>
        public String getWord()
        {
            return this.word;
        }
    }
}
