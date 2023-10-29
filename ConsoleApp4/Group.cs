using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Group : GraphicPrimitive
    {
        private List<GraphicPrimitive> children = new List<GraphicPrimitive>();

        public void AddChild(GraphicPrimitive child)
        {
            children.Add(child);
        }

        public override void Draw()
        {
            foreach (var child in children)
            {
                child.Draw();
            }
        }

        public override void Move(int x, int y)
        {
            foreach (var child in children)
            {
                child.Move(x, y);
            }
        }

        public override void Scale(float factor)
        {
            foreach (var child in children)
            {
                child.Scale(factor);
            }
        }
    }
}
