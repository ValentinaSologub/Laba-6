using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public abstract class GraphicPrimitive
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void Draw();
        public abstract void Move(int x, int y);
        public abstract void Scale(float factor);
    }
}
