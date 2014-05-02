using System;

namespace TheMatrixProject
{
    public class Matrix
    {
        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public double[,] InternalTwoDimArray { get; set; }

        public Matrix()
        {
        }

        public Matrix(int rows, int columns)
        {
            this.RowCount = rows;
            this.ColumnCount = columns;
            this.InternalTwoDimArray = new double[rows, columns];
        }

        public Matrix(double[,] twoDimArray)
        {
            this.RowCount = twoDimArray.GetLength(0);
            this.ColumnCount = twoDimArray.GetLength(1);
            this.InternalTwoDimArray = new double[RowCount, ColumnCount];

            for (int i = 0; i < this.RowCount; i++)
                for (int j = 0; j < this.ColumnCount; j++)
                    this.InternalTwoDimArray[i, j] = twoDimArray[i, j];
        }

        /// <summary>
        /// Brute force transpose method. Iterate through each row and column.
        /// </summary>
        public void Transpose()
        {
            double[,] transposedTwoDimArray = new double[this.ColumnCount, this.RowCount];

            for (int i = 0; i < this.RowCount; i++)
                for (int j = 0; j < this.ColumnCount; j++)
                    transposedTwoDimArray[i, j] = this.InternalTwoDimArray[j, i];

            this.InternalTwoDimArray = transposedTwoDimArray;
        }

        /// <summary>
        /// Calls the appropriate methods to get each row of the matrix, reverse the row,
        /// and set the reversed row to the original position in the Matrix.
        /// </summary>
        public void ReverseRows()
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                double[] row = GetRowFromMatrix(i);

                Reverse(row, 0, row.Length - 1);

                SetRowInMatrix(row, i);
            }
        }

        public double[] GetRowFromMatrix(int rowIndex)
        {
            double[] row = new double[this.ColumnCount];
            for (int j = 0; j < this.ColumnCount; j++)
                row[j] = this.InternalTwoDimArray[rowIndex, j];

            return row;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="row"></param>
        /// <param name="rowIndex"></param>
        public void SetRowInMatrix(double[] row, int rowIndex)
        {
            for (int j = 0; j < this.ColumnCount; j++)
                this.InternalTwoDimArray[rowIndex, j] = row[j];
        }

        /// <summary>
        /// Recursive array reverse. Simply swaps elements from each end of the array recursively.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void Reverse(double[] row, int start, int end)
        {
            double temp = row[start];
            row[start] = row[end];
            row[end] = temp;

            if (start == end || start == end - 1)
                return;

            Reverse(row, start + 1, end - 1);
        }

        /// <summary>
        /// Returns a string containing the values in the Matrix
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string stringToReturn = String.Empty;

            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                    stringToReturn += InternalTwoDimArray[i, j] + " ";

                stringToReturn += "\n";
            }
            return stringToReturn;
        }
    }
}