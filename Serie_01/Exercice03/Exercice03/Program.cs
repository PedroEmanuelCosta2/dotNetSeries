using System;
using System.IO;
using System.Collections.Generic;

namespace Exercice03
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> listeNbr = new List<int>();
			FileStream fileStream = new FileStream(@"../../../Mesures.txt", FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            int compteur = 0;

            using (reader){
                while(reader.Peek() >= 0){
                    listeNbr.Add(Int32.Parse(reader.ReadLine()));
                }
            }

            foreach(int nbr in listeNbr){
                compteur++;
                if (compteur%10 != 0){
                    Console.Write(nbr+" ");
                }else{
                    Console.WriteLine();
                }
            }

        }
    }
}
