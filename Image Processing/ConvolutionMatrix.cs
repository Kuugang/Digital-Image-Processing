using System;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public class ConvolutionMatrix
{
    public ConvolutionMatrix()
    {
    }

    public static Bitmap ApplyConvMatrix(Bitmap bitmap, ConvMatrix matrix)
    {
        Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);

        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

        BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

        IntPtr bitmapPtr = bitmapData.Scan0;
        IntPtr resultPtr = resultData.Scan0;

        int byteCount = bitmapData.Stride * bitmap.Height;
        byte[] pixelValues = new byte[byteCount];
        byte[] resultValues = new byte[byteCount];

        Marshal.Copy(bitmapPtr, pixelValues, 0, byteCount);

        int halfN = matrix.n / 2;
        int halfM = matrix.m / 2;

        for (int i = halfN; i < bitmap.Width - halfN; i++)
        {
            for (int j = halfM; j < bitmap.Height - halfM; j++)
            {
                int r = 0, g = 0, b = 0;

                for (int x = 0; x < matrix.n; x++)
                {
                    for (int y = 0; y < matrix.m; y++)
                    {
                        int pixelX = (i + x - halfN) * 3;
                        int pixelY = (j + y - halfM) * bitmapData.Stride;

                        int pixelIndex = pixelY + pixelX;

                        byte rVal = pixelValues[pixelIndex + 2];
                        byte gVal = pixelValues[pixelIndex + 1];
                        byte bVal = pixelValues[pixelIndex];

                        r += rVal * matrix.matrix[x, y];
                        g += gVal * matrix.matrix[x, y];
                        b += bVal * matrix.matrix[x, y];
                    }
                }

                r /= matrix.factor;
                g /= matrix.factor;
                b /= matrix.factor;

                r += matrix.offset;
                g += matrix.offset;
                b += matrix.offset;

                r = Math.Max(0, Math.Min(255, r));
                g = Math.Max(0, Math.Min(255, g));
                b = Math.Max(0, Math.Min(255, b));

                int resultIndex = (j * resultData.Stride) + (i * 3);
                resultValues[resultIndex + 2] = (byte)r;
                resultValues[resultIndex + 1] = (byte)g;
                resultValues[resultIndex] = (byte)b;
            }
        }

        Marshal.Copy(resultValues, 0, resultPtr, byteCount);

        bitmap.UnlockBits(bitmapData);
        result.UnlockBits(resultData);

        return result;
    }

    public static Bitmap Shrink(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }, 0, 1);
        return ApplyConvMatrix(bitmap, conv);
    }

    public static Bitmap Sharpen(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 0, -2, 0 }, { -2, 11, -2 }, { 0, -2, 0 } }, 0, 3);
        return ApplyConvMatrix(bitmap, conv);
    }

    public static Bitmap Blur(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }, 0, 9);
        return ApplyConvMatrix(bitmap, conv);
    }

    public static Bitmap StrongerBlur(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(5, 5, new int[5, 5] { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } }, 0, 25);
        return ApplyConvMatrix(bitmap, conv);
    }

    public static Bitmap EdgeEnhance(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } }, 0, 2);
        return ApplyConvMatrix(bitmap, conv);
    }

    public static Bitmap EdgeDetect(Bitmap bitmap, int threshold=200)
    {
        ConvMatrix hori = new ConvMatrix(3, 3, new int[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } }, 0, 1);
        ConvMatrix vert = new ConvMatrix(3, 3, new int[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } }, 0, 1);
        ConvMatrix left = new ConvMatrix(3, 3, new int[3, 3] { { 0, 1, 2 }, { -1, 0, 1 }, { -2, -1, 0 } }, 0, 1);
        ConvMatrix righ = new ConvMatrix(3, 3, new int[3, 3] { { 0, -1, -2 }, { 1, 0, -1 }, { 2, 1, 0 } }, 0, 1);

        ConvMatrix ulef = new ConvMatrix(3, 3, new int[3, 3] { { 2, 1, 0 }, { 1, 0, -1 }, { 0, -1, -2 } }, 0, 1);
        ConvMatrix urig = new ConvMatrix(3, 3, new int[3, 3] { { -2, -1, 0 }, { -1, 0, 1 }, { 0, 1, 2 } }, 0, 1);
        ConvMatrix blef = new ConvMatrix(3, 3, new int[3, 3] { { 0, -1, -2 }, { -1, 0, 1 }, { 2, 1, 0 } }, 0, 1);
        ConvMatrix brig = new ConvMatrix(3, 3, new int[3, 3] { { 0, 1, 2 }, { 1, 0, -1 }, { -2, -1, 0 } }, 0, 1);


        List<Bitmap> edges = new List<Bitmap>();
        edges.Add(ApplyConvMatrix(bitmap, hori));
        edges.Add(ApplyConvMatrix(bitmap, vert));
        edges.Add(ApplyConvMatrix(bitmap, left));
        edges.Add(ApplyConvMatrix(bitmap, righ));
        edges.Add(ApplyConvMatrix(bitmap, ulef));
        edges.Add(ApplyConvMatrix(bitmap, urig));
        edges.Add(ApplyConvMatrix(bitmap, blef));
        edges.Add(ApplyConvMatrix(bitmap, brig));

        Bitmap fin = new Bitmap(bitmap.Width, bitmap.Height);

        for (int i = 0; i < bitmap.Width; i++)
        {
            for (int j = 0; j < bitmap.Height; j++)
            {
                double sum = 0;
                for (int k = 0; k < edges.Count; k++)
                {
                    Color p = edges[k].GetPixel(i, j);
                    sum += Math.Pow(DIP.average(p), 2);
                }

                int f = DIP.clamping((int)Math.Sqrt(sum));

                fin.SetPixel(i, j, f > threshold ? Color.White : Color.Black);

            }
        }

        return fin;
    }

    public static Bitmap GaussianBlur(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(5, 5, new int[5, 5] { { 1, 4, 7, 4, 1 }, { 4, 16, 26, 16, 4 }, { 7, 26, 41, 26, 7 }, { 4, 16, 26, 16, 4 }, { 1, 4, 7, 4, 1 } }, 0, 273);
        return ApplyConvMatrix(bitmap, conv);
    }

    public static Bitmap MeanRemoval(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } }, 0, 1);
        return ApplyConvMatrix(bitmap, conv);
    }

    public static Bitmap EmbossLaplascian(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { -1, 0, -1 }, { 0, 4, 0 }, { -1, 0, -1 } }, 127, 1);
        return ApplyConvMatrix(bitmap, conv);
    }


    public static Bitmap Dilation(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }, 0, 1);
        return DIP.Thresholding(ApplyConvMatrix(bitmap, conv), 1);
    }

    public static Bitmap Erosion(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }, 0, 1);
        return DIP.Thresholding(DIP.Complement(ApplyConvMatrix(DIP.Complement(bitmap), conv)), 1);
    }
}
