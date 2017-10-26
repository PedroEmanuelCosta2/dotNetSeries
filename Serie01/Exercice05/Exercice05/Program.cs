using System;

namespace Exercice05
{
    class MainClass
    {
        /// <summary>
        /// Prints the string.
        /// </summary>
        /// <param name="s1">S1.</param>
        /// <param name="s2">S2.</param>
        /// <param name="s3">S3.</param>
        private static void PrintString(string s1, string s2, string s3)
        {
			Console.WriteLine("S1 equals S2: " + s1.Equals(s2));
			Console.WriteLine("S1 equals S3: " + s1.Equals(s3));
			Console.WriteLine("S2 equals S3: " + s2.Equals(s3));
			Console.WriteLine("S1 compareTo S2: " + s1.CompareTo(s2));
			Console.WriteLine("S1 compareTo S3: " + s1.CompareTo(s3));
			Console.WriteLine("S2 compareTo S3: " + s2.CompareTo(s3));
			Console.WriteLine("S1 System.ReferenceEquals S2: " + Object.ReferenceEquals(s1, s2));
			Console.WriteLine("S1 System.ReferenceEquals S3: " + Object.ReferenceEquals(s1, s3));
			Console.WriteLine("S2 System.ReferenceEquals S3: " + Object.ReferenceEquals(s2, s3));
        }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
			string s1 = "Hello World";
			string s2 = "Hello World";
			string s3 = s1;

            PrintString(s1,s2,s3);

            s3 += '!';

            PrintString(s1, s2, s3);

			/*Conclusion:
            String.Equals : Détermine si deux objets String ont la même valeur.
            String.CompareTo : Détermine la position de la string 2 dans la string 1
            Object.ReferenceEquals : Détermine si les instances respectives des objets sont les mêmes.
            */
		}
    }
}
