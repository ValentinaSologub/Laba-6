using ConsoleApp4;

class Program
{
    static void Main(string[] args)
    {
        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle
        {
            X = 10,
            Y = 10,
            Radius = 5
        };

        Rectangle rectangle = new Rectangle
        {
            X = 20,
            Y = 20,
            Width = 8,
            Height = 6
        };

        Triangle triangle = new Triangle
        {
            X = 30,
            Y = 30,
            SideLength = 7
        };

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);

        Group group = new Group();
        group.AddChild(circle);
        group.AddChild(rectangle);

        editor.AddPrimitive(group);

        editor.DrawAll();

        Console.ReadKey();
    }
}
