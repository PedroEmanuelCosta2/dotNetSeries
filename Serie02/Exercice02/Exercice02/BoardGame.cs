using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercice02
{
    public class BoardGame : IEnumerable
    {
        private int[] pawn;
        private char[] slots;
        private readonly int slotNumber;
        private readonly int pawnNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Exercice02.BoardGame"/> class.
        /// </summary>
        /// <param name="numberOfPlayers">Number of players.</param>
        public BoardGame(int numberOfPlayers)
        {
            pawn = new int[numberOfPlayers];
            slots = new char[26];
            slotNumber = 26;
            pawnNumber = numberOfPlayers;

            Init();
        }

        /// <summary>
        /// Print this instance.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("THE BOARD");

            foreach(char letter in slots){
                Console.Write(letter);
            }

            Console.WriteLine();

            for (int i = 1; i <= slotNumber; i++){
                if (pawn.Contains(i)){
                    Console.Write('X');
                }else{
                    Console.Write(' ');
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Init this instance.
        /// </summary>
        private void Init()
        {
            //Random object
            Random random = new Random();
            int i = 0;
            int a = 65;
            int randomNumber = 0;

            //Loop that set a different number between 1 and 26 for each player
            while(pawn[pawnNumber-1].Equals(0))
            {
                randomNumber = random.Next(1,27);
                if (!pawn.Contains(randomNumber)){
                    pawn[i] = randomNumber;
                    i++;
                }
            }

            for (int j = 0; j < slotNumber; j++){
                slots[j] = Convert.ToChar(a+j);
            }
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator GetEnumerator()
        {
            List<String> list = new List<String>();

            for (int i = 0; i < pawnNumber; i++){
                if(i<pawnNumber-1){
                    list.Add(i + ":" + this[i] + ", ");
                }else{
                    list.Add(i + ":" + this[i]);
                }

            }

            return list.GetEnumerator();
        }

        /// <summary>
        /// Gets the <see cref="T:Exercice02.BoardGame"/> with the specified letter.
        /// </summary>
        /// <param name="letter">Letter.</param>
        public bool this[char letter]{
            get { return pawn.Contains(Array.IndexOf(slots, letter) + 1); }
        }

        /// <summary>
        /// Gets the <see cref="T:Exercice02.BoardGame"/> with the specified pawnIndex.
        /// </summary>
        /// <param name="pawnIndex">Pawn index.</param>
        public char this[int pawnIndex]{
            get { return Convert.ToChar(slots[pawn[pawnIndex]-1]); }
        }
    }
}
