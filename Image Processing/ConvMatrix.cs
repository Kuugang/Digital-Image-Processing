public class ConvMatrix
{
    public int n, m;
    public int[,] matrix;
    public int offset, factor;

    public ConvMatrix(int n, int m, int[,] matrix, int offset, int factor)
    {
        this.n = n;
        this.m = m;
        this.matrix = matrix;
        this.offset = offset;
        this.factor = factor;
    }

    public void SetAll(int value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = value;
            }
        }
    }

}
