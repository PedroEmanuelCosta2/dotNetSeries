using System;

namespace Exercice02
{
    class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            BoardGame boardGame = new BoardGame(12);

            boardGame.Print();

            Console.WriteLine("THE PAWNS");

            foreach (String slotOfPawn in boardGame){
                Console.Write(slotOfPawn);
            }

            Console.WriteLine();
            Console.WriteLine("TESTING THE INDEXERS");

            Console.WriteLine("Print the slot of the Pawn 1 : " + boardGame[1]);
            Console.WriteLine("Print if the Slot A is taken or not : " + boardGame['A']);
			Console.WriteLine("Print if the Slot B is taken or not : " + boardGame['B']);
			Console.WriteLine("Print if the Slot C is taken or not : " + boardGame['C']);
        }
    }
}
