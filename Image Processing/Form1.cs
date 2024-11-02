using System.Drawing;
using System.Drawing.Imaging;
using Image_Processing.WebCamLib;

namespace Image_Processing
{
    public unsafe partial class Form1 : Form
    {
        private Bitmap loaded, processed;
        private BitmapData loadedBitmapData, processedBitmapData;
        private int width, height, bytesPerPixel, widthInPixels, heightInPixels, widthInBytes, heightInBytes;
        private byte* PtrFirstPixel, PtrFirstPixelProcessed;
        private Boolean webcam = false;
        private int webcamIndex;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private Boolean InitializeBitMapProcessing()
        {
            if (webcam)
                loaded = DeviceManager.GetDevice(webcamIndex).GetFrame();
            else
                loaded = (Bitmap)pictureBox1.Image;

            if (loaded == null) return false;

            width = loaded.Width;
            height = loaded.Height;

            processed = new Bitmap(width, height);

            bytesPerPixel = Image.GetPixelFormatSize(loaded.PixelFormat) / 8;
            loadedBitmapData = loaded.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, loaded.PixelFormat);
            processedBitmapData = processed.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, loaded.PixelFormat);

            widthInPixels = loadedBitmapData.Width;
            heightInPixels = loadedBitmapData.Height;

            widthInBytes = widthInPixels * bytesPerPixel;
            heightInBytes = heightInPixels * bytesPerPixel;

            PtrFirstPixel = (byte*)loadedBitmapData.Scan0;
            PtrFirstPixelProcessed = (byte*)processedBitmapData.Scan0;
            return true;
        }

        private void PixelCopy(object sender, EventArgs e)
        {
            this.InitializeBitMapProcessing();

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
                    }
                }
            });

            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }

        private void Greyscale(object sender, EventArgs e)
        {
            this.InitializeBitMapProcessing();
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

            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }

        private void ColorInversion(object sender, EventArgs e)
        {
            this.InitializeBitMapProcessing();
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

            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }

        private void MirrorHorizontal(object sender, EventArgs e)
        {
            this.InitializeBitMapProcessing();

            Parallel.For(0, heightInPixels, y =>
            {
                // Get the current row pointers for both source and destination images
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

            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }
        private void MirrorVertical(object sender, EventArgs e)
        {

            this.InitializeBitMapProcessing();

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

            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }

        private void Histogram(object sender, EventArgs e)
        {
            int[] histdata = new int[256];

            this.InitializeBitMapProcessing();

            Parallel.For(0, heightInPixels, y =>
            {
                byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);

                for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                {
                    histdata[loadedCurrentRow[x]]++;
                }
            });
            loaded.UnlockBits(loadedBitmapData);

            Bitmap b = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                int columnHeight = Math.Min(histdata[x] / 5, b.Height - 1);

                for (int y = 0; y < columnHeight; y++)
                {
                    b.SetPixel(x, b.Height - 1 - y, Color.Black);
                }
            }
            pictureBox2.Image = b;
        }

        private void Brightness(object sender, EventArgs e)
        {
            if (!this.InitializeBitMapProcessing()) return;
            int value = trackBar1.Value;
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
            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }

        private void Contrast(object sender, EventArgs e)
        {
            if (!this.InitializeBitMapProcessing()) return;
            int percent = trackBar2.Value;
            int width = loaded.Width;
            int height = loaded.Height;
            int numSamples = width * height;
            int[] Ymap = new int[256];
            int[] hist = new int[256];

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

            if (percent < 100)
            {
                for (int i = 0; i < 256; i++)
                {
                    Ymap[i] = i + (Ymap[i] - i) * percent / 100;
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
            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }

        public unsafe void Rotation(object sender, EventArgs e)
        {
            try
            {
                if (!this.InitializeBitMapProcessing()) return;
                int degree = trackBar3.Value;
                float angle = degree * (float)Math.PI / 180;
                int centerX = loaded.Width / 2;
                int centerY = loaded.Height / 2;

                float cosA = (float)Math.Cos(angle);
                float sinA = (float)Math.Sin(angle);

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

                    for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                    {
                        int x0 = (x / bytesPerPixel) - centerX;
                        int y0 = y - centerY;

                        int xs = (int)(x0 * cosA + y0 * sinA) + centerX;
                        int ys = (int)(-x0 * sinA + y0 * cosA) + centerY;

                        if (xs >= 0 && xs < width && ys >= 0 && ys < height)
                        {
                            byte* sourcePixel = PtrFirstPixel + ys * loadedBitmapData.Stride + xs * bytesPerPixel;

                            for(int b = 0; b < bytesPerPixel; b++)
                            {
                                processedCurrentRow[x + b] = sourcePixel[b];
                                if(b == 3)
                                    processedCurrentRow[x + b] = 255;
                            }
                        }
                    }
                });

                loaded.UnlockBits(loadedBitmapData);
                processed.UnlockBits(processedBitmapData);
                pictureBox2.Image = processed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public unsafe void Sepia(object sender, EventArgs e)
        {
            this.InitializeBitMapProcessing();

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
                    if (bytesPerPixel == 4)
                        processedCurrentRow[x + 3] = 255;
                }
            });

            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }
        private void Subtract(object sender, EventArgs e)
        {
            Color myGreen = Color.FromArgb(0, 255, 0);
            int greyGreen = (myGreen.R + myGreen.G + myGreen.B) / 3;
            int threshold = 1;

            Bitmap a = (Bitmap)pictureBox1.Image;
            Bitmap b = (Bitmap)pictureBox2.Image;

            Bitmap result = new Bitmap(a.Width, a.Height);

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
                        result.SetPixel(x, y, adata);
                    else
                        result.SetPixel(x, y, bdata);
                }
            }
            pictureBox3.Image = result;
            processed = b;
        }

        private void Threshold(object sender, EventArgs e)
        {
            if (!this.InitializeBitMapProcessing()) return;

            Bitmap a = (Bitmap)pictureBox1.Image;
            Bitmap b = new Bitmap(a.Width, a.Height);
            int value = trackBar4.Value;
            byte graydata = 0;

            Parallel.For(0, heightInPixels, y =>
            {
                byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
                byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

                for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                {
                    byte blue = loadedCurrentRow[x];
                    byte green = loadedCurrentRow[x + 1];
                    byte red = loadedCurrentRow[x + 2];

                    graydata = (byte)((blue + green + red) / 3);
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
            });

            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
        }

        private void openBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pictureBox2.Image = new Bitmap(openFileDialog2.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            processed.Save(saveFileDialog1.FileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Device[] devices = DeviceManager.GetAllDevices();
            devicesToolStripMenuItem.DropDownItems.Clear();
            devicesToolStripMenuItem.DropDownItems.AddRange(devices.Select(d =>
            {
                var menuItem = new ToolStripMenuItem(d.Name)
                {
                    Tag = d
                };
                menuItem.Click += DeviceMenuItem_Click;
                return menuItem;
            }).ToArray());
        }

        private void DeviceMenuItem_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is Device device)
            {
                webcam = true;
                webcamIndex = device.Index;
                device.ShowWindow(pictureBox1);
            }
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcam)
            {
                DeviceManager.GetDevice(webcamIndex).Stop();
                webcam = false;
            }
        }
    }
}
