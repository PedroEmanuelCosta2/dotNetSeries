using System;

namespace Exercice01
{
    class MainClass
    {

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

            public void print(){
                Console.WriteLine("("+x+" ,"+y+" ,"+z+") distance à l'origine : "+distanceToOrigin());
            }
        };

        public static void swapPoint(ref Point3D pt1, ref Point3D pt2){
            Point3D tmp = pt1;
            pt1 = pt2;
            pt2 = tmp;
        }

        public static void Main(string[] args)
        {
            Point3D point1 = new Point3D(1, 2, 3);
            Point3D point2 = new Point3D(4, 5, 6);

            point1.print();
            point2.print();

            swapPoint(ref point1, ref point2);

            point1.print();
            point2.print();

        }
    }
}
