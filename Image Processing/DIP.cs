using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

public unsafe class DIP
{

    private static int bytesPerPixel, widthInPixels, heightInPixels, widthInBytes, heightInBytes;
    private static byte* PtrFirstPixel, PtrFirstPixelProcessed;
    private static BitmapData loadedBitmapData;
    private static BitmapData processedBitmapData;
    public static Bitmap Run(Bitmap bitmap, Func<Bitmap, int, int, Color> func)
    {
        Bitmap processed = new Bitmap(bitmap.Width, bitmap.Height);

        for (int i = 0; i < bitmap.Width; i++)
        {
            for (int j = 0; j < bitmap.Height; j++)
            {
                processed.SetPixel(i, j, func(bitmap, i, j));
            }
        }

        return processed;
    }

    private static void InitializeBitMapProcessing(ref Bitmap a, ref Bitmap b)
    {
        bytesPerPixel = Image.GetPixelFormatSize(a.PixelFormat) / 8;

        loadedBitmapData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadOnly, a.PixelFormat);
        processedBitmapData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.WriteOnly, a.PixelFormat);

        widthInPixels = loadedBitmapData.Width;
        heightInPixels = loadedBitmapData.Height;

        widthInBytes = widthInPixels * bytesPerPixel;
        heightInBytes = heightInPixels * bytesPerPixel;

        PtrFirstPixel = (byte*)loadedBitmapData.Scan0;
        PtrFirstPixelProcessed = (byte*)processedBitmapData.Scan0;
    }

    public static void PixelCopy(ref Bitmap a, ref Bitmap b)
    {
        InitializeBitMapProcessing(ref a, ref b);
        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                // B -> G -> R -> A
                for (int b = 0; b < bytesPerPixel; b++)
                {
                    processedCurrentRow[x + b] = loadedCurrentRow[x + b];
                    if (b == 3)
                    {
                        processedCurrentRow[x + b] = 255;
                    }
                }
            }
        });

        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);
    }

    public static void Greyscale(ref Bitmap a, ref Bitmap b)
    {
        InitializeBitMapProcessing(ref a, ref b);

        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                for (int b = 0; b < bytesPerPixel; b++)
                {
                    processedCurrentRow[x + b] = (byte)((loadedCurrentRow[x] + loadedCurrentRow[x + 1] + loadedCurrentRow[x + 2]) / 3);
                    if (b == 3)
                        processedCurrentRow[x + b] = 255;
                }
            }
        });

        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);
    }
    public static void ColorInversion(ref Bitmap a, ref Bitmap b)
    {
        InitializeBitMapProcessing(ref a, ref b);

        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                for (int b = 0; b < bytesPerPixel; b++)
                {
                    processedCurrentRow[x + b] = (byte)(255 - loadedCurrentRow[x + b]);
                    if (b == 3)
                        processedCurrentRow[x + b] = 255;
                }
            }
        });

        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);
    }

    public static void MirrorHorizontal(ref Bitmap a, ref Bitmap b)
    {
        InitializeBitMapProcessing(ref a, ref b);

        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* mirroredRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes / 2; x += bytesPerPixel)
            {
                int mirroredX = widthInBytes - bytesPerPixel - x;

                for (int b = 0; b < bytesPerPixel; b++)
                {
                    mirroredRow[x + b] = loadedCurrentRow[mirroredX + b];
                    mirroredRow[mirroredX + b] = loadedCurrentRow[x + b];
                }
            }
        });

        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);
    }

    public static void MirrorVertical(ref Bitmap a, ref Bitmap b)
    {
        InitializeBitMapProcessing(ref a, ref b);

        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* mirroredLine = PtrFirstPixelProcessed + ((heightInPixels - 1 - y) * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                for (int b = 0; b < bytesPerPixel; b++)
                {
                    mirroredLine[x + b] = loadedCurrentRow[x + b];
                }
            }
        });
        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);
    }
    public static void Histogram(ref Bitmap a, ref Bitmap b)
    {
        InitializeBitMapProcessing(ref a, ref b);
        int[] histdata = new int[256];

        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                histdata[loadedCurrentRow[x]]++;
            }
        });

        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);

        b = new Bitmap(256, 800);
        for (int x = 0; x < 256; x++)
        {
            int columnHeight = Math.Min(histdata[x] / 5, b.Height - 1);

            for (int y = 0; y < columnHeight; y++)
            {
                b.SetPixel(x, b.Height - 1 - y, Color.Black);
            }
        }
    }

    public static void Sepia(ref Bitmap a, ref Bitmap b)
    {
        InitializeBitMapProcessing(ref a, ref b);
        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                byte blue = loadedCurrentRow[x];
                byte green = loadedCurrentRow[x + 1];
                byte red = loadedCurrentRow[x + 2];

                processedCurrentRow[x] = (byte)Math.Min((int)(red * 0.272 + green * 0.534 + blue * 0.131), 255);
                processedCurrentRow[x + 1] = (byte)Math.Min((int)(red * 0.349 + green * 0.686 + blue * 0.168), 255);
                processedCurrentRow[x + 2] = (byte)Math.Min((int)(red * 0.393 + green * 0.769 + blue * 0.189), 255);
                processedCurrentRow[x + 2] = (byte)Math.Min((int)(red * 0.393 + green * 0.769 + blue * 0.189), 255);
                if (bytesPerPixel == 4)
                    processedCurrentRow[x + 3] = 255;
            }
        });

        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);
    }

    public static void Brightness(ref Bitmap a, ref Bitmap b, int value)
    {
        InitializeBitMapProcessing(ref a, ref b);
        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                byte blue = loadedCurrentRow[x];
                byte green = loadedCurrentRow[x + 1];
                byte red = loadedCurrentRow[x + 2];

                if (value > 0)
                {
                    blue = (byte)Math.Min(blue + value, 255);
                    green = (byte)Math.Min(green + value, 255);
                    red = (byte)Math.Min(red + value, 255);
                }
                else
                {
                    blue = (byte)Math.Max(blue + value, 0);
                    green = (byte)Math.Max(green + value, 0);
                    red = (byte)Math.Max(red + value, 0);
                }

                for (int b = 0; b < bytesPerPixel; b++)
                {
                    processedCurrentRow[x + b] = (b == 3) ? (byte)255 : (b == 0) ? blue : (b == 1) ? green : red;
                }
            }
        });
        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);

    }

    public static void Contrast(ref Bitmap a, ref Bitmap b, int value)
    {
        int width = a.Width;
        int height = b.Height;
        int numSamples = width * height;
        int[] Ymap = new int[256];
        int[] hist = new int[256];

        InitializeBitMapProcessing(ref a, ref b);

        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                byte average = 0;
                for (int b = 0; b < bytesPerPixel; b++)
                {
                    processedCurrentRow[x + b] = loadedCurrentRow[x + b];
                    if (b == 3)
                    {
                        processedCurrentRow[x + b] = 255;
                        break;
                    }
                    average += (byte)loadedCurrentRow[x + b];
                }
                average /= 3;
                hist[average]++;
            }
        });

        int histSum = 0;
        for (int i = 0; i < 256; i++)
        {
            histSum += hist[i];
            Ymap[i] = histSum * 255 / numSamples;
        }

        if (value < 100)
        {
            for (int i = 0; i < 256; i++)
            {
                Ymap[i] = i + (Ymap[i] - i) * value / 100;
            }
        }

        Parallel.For(0, heightInPixels, y =>
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {

                byte blue = loadedCurrentRow[x];

                int adjustedGray = Ymap[blue];

                for (int b = 0; b < bytesPerPixel; b++)
                {
                    processedCurrentRow[x + b] = (byte)adjustedGray;
                    if (b == 3)
                        processedCurrentRow[x + b] = 255;
                }
            }
        });
        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);
    }

    public static void Rotation(ref Bitmap a, ref Bitmap b, int degree)
    {
        InitializeBitMapProcessing(ref a, ref b);

        float radians = degree * (float)Math.PI / 180;
        int centerX = a.Width / 2;
        int centerY = a.Height / 2;

        float cosA = (float)Math.Cos(radians);
        float sinA = (float)Math.Sin(radians);

        Parallel.For(0, heightInPixels, y =>
        {
            byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                int x0 = (x / bytesPerPixel) - centerX;
                int y0 = y - centerY;

                int xs = (int)(x0 * cosA + y0 * sinA) + centerX;
                int ys = (int)(-x0 * sinA + y0 * cosA) + centerY;

                if (xs >= 0 && xs < widthInPixels && ys >= 0 && ys < heightInPixels)
                {
                    byte* sourcePixel = PtrFirstPixel + ys * loadedBitmapData.Stride + xs * bytesPerPixel;

                    for (int b = 0; b < bytesPerPixel; b++)
                    {
                        processedCurrentRow[x + b] = sourcePixel[b];
                        if (b == 3)
                            processedCurrentRow[x + b] = 255;
                    }
                }
            }
        });

        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);
    }

    public static void Threshold(ref Bitmap a, ref Bitmap b, int value)
    {
        InitializeBitMapProcessing(ref a, ref b);
        int graydata = 0;

        for (int y = 0; y < heightInPixels; y++)
        {
            byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
            byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

            for (int x = 0; x < widthInBytes; x += bytesPerPixel)
            {
                int blue = loadedCurrentRow[x];
                int green = loadedCurrentRow[x + 1];
                int red = loadedCurrentRow[x + 2];

                graydata = (blue + green + red) / 3;
                if (graydata > value)
                {
                    processedCurrentRow[x] = 255;
                    processedCurrentRow[x + 1] = 255;
                    processedCurrentRow[x + 2] = 255;
                }
                else
                {
                    processedCurrentRow[x] = 0;
                    processedCurrentRow[x + 1] = 0;
                    processedCurrentRow[x + 2] = 0;
                }
                if (bytesPerPixel == 4)
                    processedCurrentRow[x + 3] = 255;
            }
        };

        a.UnlockBits(loadedBitmapData);
        b.UnlockBits(processedBitmapData);
    }

    public static void Subtract(ref Bitmap a, ref Bitmap b, ref Bitmap c, Color color)
    {
        int greyGreen = (color.R + color.G + color.B) / 3;
        int threshold = 1;

        byte agraydata = 0;
        byte bgraydata = 0;
        for (int x = 0; x < a.Width; x++)
        {
            for (int y = 0; y < a.Height; y++)
            {
                Color adata = a.GetPixel(x, y);
                Color bdata = b.GetPixel(x, y);

                agraydata = (byte)((adata.R + adata.G + adata.B) / 3);
                bgraydata = (byte)((bdata.R + bdata.G + bdata.B) / 3);

                if (Math.Abs(agraydata - greyGreen) > threshold)
                    c.SetPixel(x, y, adata);
                else
                    c.SetPixel(x, y, bdata);
            }
        }
    }

    public static int average(Color pixel)
    {
        return (int)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
    }

    public static int clamping(int a)
    {
        return Math.Max(Math.Min(a, 255), 0);
    }

    public static Bitmap MedianFilter(Bitmap bitmap, int windowSize)
    {
        Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
        int halfSize = windowSize / 2;

        for (int i = halfSize; i < bitmap.Width - halfSize; i++)
        {
            for (int j = halfSize; j < bitmap.Height - halfSize; j++)
            {
                List<int> reds = new List<int>();
                List<int> greens = new List<int>();
                List<int> blues = new List<int>();

                // Collect pixel values in the window
                for (int x = -halfSize; x <= halfSize; x++)
                {
                    for (int y = -halfSize; y <= halfSize; y++)
                    {
                        Color pixel = bitmap.GetPixel(i + x, j + y);
                        reds.Add(pixel.R);
                        greens.Add(pixel.G);
                        blues.Add(pixel.B);
                    }
                }

                // Get the median of each channel
                reds.Sort();
                greens.Sort();
                blues.Sort();

                int medianR = reds[reds.Count / 2];
                int medianG = greens[greens.Count / 2];
                int medianB = blues[blues.Count / 2];

                result.SetPixel(i, j, Color.FromArgb(medianR, medianG, medianB));
            }
        }

        return result;
    }
    public static Bitmap Thresholding(Bitmap bitmap, int threshold)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color p = bitmap.GetPixel(i, j);
            int avg = average(p);
            return avg < threshold ? Color.Black : Color.White;
        });
    }
    public static Bitmap Complement(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            return average(bitmap.GetPixel(i, j)) != 0 ? Color.Black : Color.White;
        });
    }
    public static Bitmap GrayScale(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixel = bitmap.GetPixel(i, j);
            int avg = average(pixel);
            return Color.FromArgb(avg, avg, avg);
        });
    }
    public static Bitmap ResizeImage(Bitmap a, Bitmap b)
    {
        Bitmap resizedImage = new Bitmap(b.Width, b.Height);
        using (Graphics g = Graphics.FromImage(resizedImage))
        {
            g.DrawImage(a, 0, 0, b.Width, b.Height);
        }
        return resizedImage;
    }
}
