using System;
using System.Collections.Generic;
using System.Linq;

namespace TheMatrixProject
{
    public class Matrix
    {
        #region |-- Properties --|

        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public double[,] InternalTwoDimArray { get; set; }

        #endregion |-- Properties --|

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

        ///PROBLEM WITH NON-SQUARE MATRICES: FIX
        /// <summary>
        /// Brute force transpose method. Iterate through each row and column.
        /// </summary>
        public void Transpose()
        {
            double[,] transposedTwoDimArray = new double[this.ColumnCount, this.RowCount];

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
                IEnumerable<double> row = GetRowFromMatrix(i);

                row = Reverse(row);

                SetRowInMatrix(row, i);
            }
        }

        public IEnumerable<double> GetRowFromMatrix(int rowIndex)
        {
            double[] row = new double[this.ColumnCount];
            for (int j = 0; j < this.ColumnCount; j++)
                row[j] = this.InternalTwoDimArray[rowIndex, j];

            return row;
        }

        /// <summary>
        /// Replaces the row in the Matrix specified by rowIndex with the double array "row"
        /// </summary>
        /// <param name="row"></param>
        /// <param name="rowIndex"></param>
        public void SetRowInMatrix(IEnumerable<double> row, int rowIndex)
        {
            for (int j = 0; j < this.ColumnCount; j++)
                this.InternalTwoDimArray[rowIndex, j] = row.ElementAt(j);
        }

        /// <summary>
        /// Replaces the column in the Matrix specified by columnIndex with the double array "column"
        /// </summary>
        /// <param name="column"></param>
        /// <param name="columnIndex"></param>
        public void SetColumnInMatrix(double[] column, int columnIndex)
        {
            for (int i = 0; i < this.RowCount; i++)
                this.InternalTwoDimArray[i, columnIndex] = column[i];
        }

        private IEnumerable<double> Reverse(IEnumerable<double> array)
        {
            var count = array.Count();
            if (count < 2)
                return array;
            var midPoint = count >> 1;
            return Reverse(array.Skip(midPoint).Take(count - midPoint))
                                    .Concat(Reverse(array.Take(midPoint)));
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