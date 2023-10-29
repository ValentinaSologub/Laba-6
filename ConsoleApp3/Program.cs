

class Program
{
    static void Main(string[] args)
    {
        double number1 = 10.5;
        double number2 = 5.3;

        
        double result1 = MathOperations.Add(number1, number2);
        Console.WriteLine($"Adding numbers: {number1} + {number2} = {result1}");

        double[] array1 = { 1.0, 2.0, 3.0 };
        double[] array2 = { 4.0, 5.0, 6.0 };

        
        double[] result2 = MathOperations.Add(array1, array2);
        Console.WriteLine("Adding arrays of numbers:");
        Console.WriteLine(string.Join(", ", result2));

        double[,] matrix1 = { { 1.0, 2.0 }, { 3.0, 4.0 } };
        double[,] matrix2 = { { 5.0, 6.0 }, { 7.0, 8.0 } };

        
        double[,] result3 = MathOperations.Add(matrix1, matrix2);
        Console.WriteLine("Adding matrices:");
        for (int i = 0; i < result3.GetLength(0); i++)
        {
            for (int j = 0; j < result3.GetLength(1); j++)
            {
                Console.Write(result3[i, j] + " ");
            }
            Console.WriteLine();
        }

        double[,,] tensor1 = { { { 1.0, 2.0 }, { 3.0, 4.0 } }, { { 5.0, 6.0 }, { 7.0, 8.0 } } };
        double[,,] tensor2 = { { { 9.0, 10.0 }, { 11.0, 12.0 } }, { { 13.0, 14.0 }, { 15.0, 16.0 } } };

        
        double[,,] result4 = MathOperations.Add(tensor1, tensor2);
        Console.WriteLine("Addition of tensors:");
        for (int d = 0; d < result4.GetLength(0); d++)
        {
            for (int i = 0; i < result4.GetLength(1); i++)
            {
                for (int j = 0; j < result4.GetLength(2); j++)
                {
                    Console.Write(result4[d, i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        Console.ReadLine(); 
    }
}