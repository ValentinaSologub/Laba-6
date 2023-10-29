

public class MathOperations
{
    
    public static double Add(double a, double b)
    {
        return a + b;
    }

    
    public static double[] Add(double[] array1, double[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        double[] result = new double[array1.Length];
        for (int i = 0; i < array1.Length; i++)
        {
            result[i] = array1[i] + array2[i];
        }
        return result;
    }

   
    public static double[,] Add(double[,] matrix1, double[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        if (matrix2.GetLength(0) != rows || matrix2.GetLength(1) != cols)
            throw new ArgumentException("Matrices must have the same dimensions.");

        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    
    public static double[,,] Add(double[,,] tensor1, double[,,] tensor2)
    {
        int depth = tensor1.GetLength(0);
        int rows = tensor1.GetLength(1);
        int cols = tensor1.GetLength(2);

        if (tensor2.GetLength(0) != depth || tensor2.GetLength(1) != rows || tensor2.GetLength(2) != cols)
            throw new ArgumentException("Tensors must have the same dimensions.");

        double[,,] result = new double[depth, rows, cols];
        for (int d = 0; d < depth; d++)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[d, i, j] = tensor1[d, i, j] + tensor2[d, i, j];
                }
            }
        }
        return result;
    }

   
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    
    public static double[] Subtract(double[] array1, double[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        double[] result = new double[array1.Length];
        for (int i = 0; i < array1.Length; i++)
        {
            result[i] = array1[i] - array2[i];
        }
        return result;
    }


    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    
    public static double[] Multiply(double[] array, double scalar)
    {
        double[] result = new double[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = array[i] * scalar;
        }
        return result;
    }

   
    public static double[,] Multiply(double[,] matrix, double scalar)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }
        return result;
    }

    
    public static double[,,] Multiply(double[,,] tensor, double scalar)
    {
        int depth = tensor.GetLength(0);
        int rows = tensor.GetLength(1);
        int cols = tensor.GetLength(2);

        double[,,] result = new double[depth, rows, cols];
        for (int d = 0; d < depth; d++)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[d, i, j] = tensor[d, i, j] * scalar;
                }
            }
        }
        return result;
    }
}