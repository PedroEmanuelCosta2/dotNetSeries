using System;

namespace Exercice02
{
    class MainClass
    {
        private static double a;
        private static int compteur;

        private static void calculSqrt(double val){
            double sqrt = (val + a / val) / 2;

            if ((sqrt - Math.Sqrt(a)) > a*Math.Pow(10,-9)){
                Console.WriteLine("Approximation de la racine carrée de "+a+" est de "+sqrt);
                compteur++;
                calculSqrt(sqrt);
            }
        }

        public static void Main(string[] args)
        {
            a = -1;
            compteur = 0;

            while(a < 0){
                Console.Write("Number must be positif. Insert the value : ");
                if (!double.TryParse(Console.ReadLine(), out a))
				{
					Console.WriteLine("Parsing Error");
				}
            }

            DateTime starttime = DateTime.Now;
            calculSqrt(a);
            TimeSpan tempsecoule = DateTime.Now - starttime;

            Console.WriteLine("Temps écoulé : "+tempsecoule.Seconds+" secondes");
            Console.WriteLine("Nombre d'itérations : "+compteur);
        }
    }
}
