using System;
using System.IO;
using System.Collections.Generic;

namespace Exercice03
{
    class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            List<int> listeNbr = new List<int>();
			FileStream fileStream = new FileStream(@"../../../Mesures.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            int compteur = 0;

            using (reader){
                while(reader.Peek() >= 0){
                    listeNbr.Add(Int16.Parse(reader.ReadLine()));
                }
            }

            foreach(int nbr in listeNbr){
                compteur++;
                if (compteur%10 != 0){
                    Console.Write(nbr+" ");
                }else{
                    Console.Write(nbr + " ");
                    Console.WriteLine();
                }
            }

        }
    }
}
