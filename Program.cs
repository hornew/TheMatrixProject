using System;

namespace TheMatrixProject
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const int columns = 10;
            const int rows = 10;

            double[,] array2D = new double[rows, columns];
            int rowCount = array2D.GetLength(0);    //calculate the counts here to avoid calling method through each pass of the loop
            int columnCount = array2D.GetLength(1);

            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    array2D[i, j] = i * j + i;

            Matrix mat = new Matrix(array2D);

            Console.WriteLine(mat.ToString());

            mat.Transpose();

            Console.WriteLine(mat.ToString());  //print the transposed matrix

            Matrix eye = new IdentityMatrix(10);

            Console.WriteLine(eye.ToString());  //print the 10 x 10 identity matrix

            eye.ReverseRows();

            Console.WriteLine(eye.ToString());  //print the identity matrix with rows reversed.
        }
    }
}