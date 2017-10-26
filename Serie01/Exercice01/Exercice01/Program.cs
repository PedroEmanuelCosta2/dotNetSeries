using System;

namespace Exercice01
{
    class MainClass
    {
        /// <summary>
        /// Struct of a 3D point wich can calculate the distance from the origin and print the 3 coordinates
        /// </summary>
        public struct Point3D
        {
            float x, y, z;
            public Point3D(float x, float y, float z){
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public float distanceToOrigin(){
                return (float)Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2) + Math.Pow(z,2));
            }

            public override string ToString(){
                return "("+x+" ,"+y+" ,"+z+") distance à l'origine : "+distanceToOrigin();
            }
        };

        /// <summary>
        /// Swap 2 structure Point
        /// </summary>
        /// <param name="pt1">Pt1.</param>
        /// <param name="pt2">Pt2.</param>
        public static void swapPoint(ref Point3D pt1, ref Point3D pt2){
            Point3D tmp = pt1;
            pt1 = pt2;
            pt2 = tmp;
        }
        
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            Point3D point1 = new Point3D(1, 2, 3);
            Point3D point2 = new Point3D(4, 5, 6);

            Console.WriteLine(point1);
            Console.WriteLine(point2);

            swapPoint(ref point1, ref point2);

            Console.WriteLine(point1);
            Console.WriteLine(point2);

        }
    }
}
