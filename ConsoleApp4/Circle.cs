using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Circle : GraphicPrimitive
    {
        public int Radius { get; set; }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a circle at ({X}, {Y}) with radius {Radius}");

            int centerX = X + Radius;
            int centerY = Y + Radius;

            for (int i = 0; i <= Radius * 2; i++)
            {
                for (int j = 0; j <= Radius * 2; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(i - Radius, 2) + Math.Pow(j - Radius, 2));
                    if (distance < Radius + 0.5)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public override void Move(int x, int y)
        {
            X += x;
            Y += y;
        }

        public override void Scale(float factor)
        {
            Radius = (int)(Radius * factor);
        }
    }
}
