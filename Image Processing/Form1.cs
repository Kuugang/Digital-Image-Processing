using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Image_Processing
{
    public unsafe partial class Form1 : Form
    {
        Boolean ISWEBCAM;
        private Bitmap loaded, processed;
        private BitmapData loadedBitmapData, processedBitmapData;
        private int width, height, bytesPerPixel, widthInPixels, heightInPixels, widthInBytes, heightInBytes;
        private byte* PtrFirstPixel, PtrFirstPixelProcessed;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeBitMapProcessing()
        {
            processed = new Bitmap(width, height, loaded.PixelFormat);
            loadedBitmapData = loaded.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, loaded.PixelFormat);
            processedBitmapData = processed.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, processed.PixelFormat);
            widthInPixels = loadedBitmapData.Width;
            heightInPixels = loadedBitmapData.Height;

            widthInBytes = widthInPixels * bytesPerPixel;
            heightInBytes = heightInPixels * bytesPerPixel;

            PtrFirstPixel = (byte*)loadedBitmapData.Scan0;
            PtrFirstPixelProcessed = (byte*)processedBitmapData.Scan0;
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
                    byte blue = loadedCurrentRow[x];
                    byte green = loadedCurrentRow[x + 1];
                    byte red = loadedCurrentRow[x + 2];

                    processedCurrentRow[x] = blue;
                    processedCurrentRow[x + 1] = green;
                    processedCurrentRow[x + 2] = red;
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
                    byte blue = loadedCurrentRow[x];
                    byte green = loadedCurrentRow[x + 1];
                    byte red = loadedCurrentRow[x + 2];
                    byte average = (byte)((blue + green + red) / 3);

                    processedCurrentRow[x] = average;
                    processedCurrentRow[x + 1] = average;
                    processedCurrentRow[x + 2] = average;
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
                    byte blue = loadedCurrentRow[x];
                    byte green = loadedCurrentRow[x + 1];
                    byte red = loadedCurrentRow[x + 2];

                    processedCurrentRow[x] = (byte)(255 - blue);
                    processedCurrentRow[x + 1] = (byte)(255 - green);
                    processedCurrentRow[x + 2] = (byte)(255 - red);
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
                byte* loadedCurrentRow = PtrFirstPixel + (y * loadedBitmapData.Stride);
                byte* processedCurrentRow = PtrFirstPixelProcessed + (y * processedBitmapData.Stride);

                for (int x = 0; x < loadedBitmapData.Width; x++)
                {
                    int mirroredX = (loadedBitmapData.Width - 1 - x) * bytesPerPixel;
                    int originalX = x * bytesPerPixel;

                    processedCurrentRow[mirroredX] = loadedCurrentRow[originalX];         // Blue
                    processedCurrentRow[mirroredX + 1] = loadedCurrentRow[originalX + 1]; // Green
                    processedCurrentRow[mirroredX + 2] = loadedCurrentRow[originalX + 2]; // Red
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
                    mirroredLine[x] = loadedCurrentRow[x];       // Blue
                    mirroredLine[x + 1] = loadedCurrentRow[x + 1]; // Green
                    mirroredLine[x + 2] = loadedCurrentRow[x + 2]; // Red
                    if (bytesPerPixel == 4)
                        mirroredLine[x + 3] = loadedCurrentRow[x + 3];
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
            int value = trackBar1.Value;
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

                    processedCurrentRow[x] = blue;
                    processedCurrentRow[x + 1] = green;
                    processedCurrentRow[x + 2] = red;
                }
            });
            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }

        private void Contrast(object sender, EventArgs e)
        {
            this.InitializeBitMapProcessing();
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
                    byte blue = loadedCurrentRow[x];
                    byte green = loadedCurrentRow[x + 1];
                    byte red = loadedCurrentRow[x + 2];
                    byte average = (byte)((blue + green + red) / 3);

                    processedCurrentRow[x] = average;
                    processedCurrentRow[x + 1] = average;
                    processedCurrentRow[x + 2] = average;
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
                    byte green = loadedCurrentRow[x + 1];
                    byte red = loadedCurrentRow[x + 2];

                    int adjustedGray = Ymap[blue];

                    processedCurrentRow[x] = (byte)adjustedGray;
                    processedCurrentRow[x + 1] = (byte)adjustedGray;
                    processedCurrentRow[x + 2] = (byte)adjustedGray;
                }
            });
            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
        }

        public unsafe void Rotation(object sender, EventArgs e)
        {
            this.InitializeBitMapProcessing();
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

                        processedCurrentRow[x] = sourcePixel[0];
                        processedCurrentRow[x + 1] = sourcePixel[1];
                        processedCurrentRow[x + 2] = sourcePixel[2];
                    }
                }
            });

            loaded.UnlockBits(loadedBitmapData);
            processed.UnlockBits(processedBitmapData);
            pictureBox2.Image = processed;
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
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
            width = loaded.Width;
            height = loaded.Height;

            bytesPerPixel = Image.GetPixelFormatSize(loaded.PixelFormat) / 8;
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
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor
            foreach (FilterInfo Device in videoDevices)
            {
                //comboBox1.Items.Add(Device.Name);
                MessageBox.Show(Device.ToString());
            }

            //comboBox1.SelectedIndex = 0; // default
            videoSource = new VideoCaptureDevice();
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;

            if (menuItem != null)
            {
                ISWEBCAM = menuItem.Text == "Off";
                menuItem.Text = ISWEBCAM ? "On" : "Off";
            }
        }


        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Number of video devices found: {videoDevices.Count}");

                foreach (var device in videoDevices)
                {
                    MessageBox.Show($"Device: {device.ToString()}");
                }

                if (videoDevices.Count > 0)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[1].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                    videoSource.Start();

                    if (videoSource.IsRunning)
                    {
                        MessageBox.Show("Camera is now running.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to start the camera.");
                    }
                }
                else
                {
                    MessageBox.Show("No video sources found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Display the current frame in the PictureBox
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the video capture when closing the form
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }
    }
}
