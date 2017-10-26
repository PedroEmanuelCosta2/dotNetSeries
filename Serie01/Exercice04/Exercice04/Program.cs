using System;
using System.Collections.Generic;

namespace Exercice04
{
    class MainClass
    {
        private static List<int> listePaire = new List<int>();
        private static List<int> listeImpaire = new List<int>();

        /// <summary>
        /// Define the pair and impair number of an array
        /// </summary>
        /// <param name="tab">Tab.</param>
		private static void PairImpair(int[] tab)
		{
            Console.WriteLine("Appel de PairImpair");
            for (int i = 0; i < tab.Length; i++){
                if(tab[i]%2==0){
                    listePaire.Add(tab[i]);
                }else{
                    listeImpaire.Add(tab[i]);
                }
            }
		}

        /// <summary>
        /// Prints the tables.
        /// </summary>
        private static void PrintTables(){
            Console.WriteLine("Pair : ");
            foreach(int paire in listePaire){
                Console.Write(paire + " ");
            }

            Console.WriteLine();

			Console.WriteLine("Impaire : ");
            foreach (int impaire in listeImpaire)
			{
                Console.Write(impaire + " ");
			}
        }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            int[] tab = new int[20];
            Random rand = new Random();

            Console.WriteLine("Valeurs à séparer : ");

            for (int i = 0; i < tab.Length; i++){
                tab[i] = rand.Next(0,99);
                Console.Write(tab[i]+" ");
            }

            Console.WriteLine();

            PairImpair(tab);
            PrintTables();
        }
    }
}
