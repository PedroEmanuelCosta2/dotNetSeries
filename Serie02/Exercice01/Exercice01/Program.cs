using System;

namespace Exercice01
{
    class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
			int num1, num2;
			decimal result = 0;
			Console.WriteLine("DIVISION. Entrez 2 nombres, je calcule le quotient"); 

            try{
				Console.WriteLine("Entrez le 1er nombre: ");
				num1 = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Entrez le 2ème nombre: ");
				num2 = Convert.ToInt32(Console.ReadLine());
				result = (decimal)num1 / (decimal)num2;
            }catch(OverflowException caught){
                Console.WriteLine(caught.Message);
            }catch(DivideByZeroException caught){
                Console.WriteLine(caught.Message);
            }catch(FormatException caught){
                Console.WriteLine(caught.Message);
            }

			Console.WriteLine("Divide : " + result.ToString());
			Console.ReadLine();
        }
    }
}
