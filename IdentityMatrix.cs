namespace TheMatrixProject
{
    public class IdentityMatrix : Matrix
    {
        public IdentityMatrix(int n)
        {
            this.RowCount = n;
            this.ColumnCount = n;
            this.InternalTwoDimArray = new double[this.RowCount, this.ColumnCount];

            for (int i = 0; i < this.RowCount; i++)
                this.InternalTwoDimArray[i, i] = 1;
        }

        public string ToString()
        {
            return base.ToString();
        }
    }
}