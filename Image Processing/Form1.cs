using Image_Processing.WebCamLib;
using System.Diagnostics;

using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows.Forms;

namespace Image_Processing
{
    public unsafe partial class Form1 : Form
    {
        private Bitmap loaded, processed, imgA, imgB, coins;
        private Color subtractColor = Color.FromArgb(255, 0, 255, 1);

        private Boolean webcam = false;
        private String webcamDIPMode;
        private int webcamIndex;
        FilterInfoCollection fic;
        VideoCaptureDevice vcd;


        public Form1()
        {
            InitializeComponent();
            InitImage();
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            vcd = new VideoCaptureDevice();

            foreach (FilterInfo dev in fic)
            {
                comboBox1.Items.Add(dev.Name);
                comboBox1.SelectedIndex = 0;
            }
        }

        public void InitImage()
        {
            String dip = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\Images\\dip.jpg");
            if (System.IO.File.Exists(dip))
            {
                loaded = new Bitmap(dip);
                pictureBox1.Image = loaded;
            }
            String suba = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\Images\\imgA.png");
            if (System.IO.File.Exists(suba))
            {
                imgA = new Bitmap(suba);
                SubtractPic1.Image = imgA;
            }

            String subb = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\Images\\imgB.png");
            if (System.IO.File.Exists(subb))
            {
                imgB = new Bitmap(subb);
                SubtractPic2.Image = imgB;
            }

            String coinsPath = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\Images\\coins.jpeg");
            if (System.IO.File.Exists(coinsPath))
            {
                coins = new Bitmap(coinsPath);
                pictureBoxCoins.Image = coins;
            }
            pictureBoxSubtractColor.BackColor = subtractColor;
        }

        private Boolean GetBitmaps()
        {
            loaded = (Bitmap)pictureBox1.Image;
            if (loaded == null)
            {
                return false;
            }
            processed = new Bitmap(loaded.Width, loaded.Height);
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;

            if (webcam == false)
            {
                timer1.Stop();
                return;
            }

            switch (webcamDIPMode)
            {
                case "PixelCopy":
                    global::DIP.PixelCopy(ref loaded, ref processed);
                    break;
                case "Greyscale":
                    global::DIP.Greyscale(ref loaded, ref processed);
                    break;
                case "Color Inversion":
                    global::DIP.ColorInversion(ref loaded, ref processed);
                    break;
                case "Mirror Horizontal":
                    global::DIP.MirrorHorizontal(ref loaded, ref processed);
                    break;
                case "Mirror Vertical":
                    global::DIP.MirrorVertical(ref loaded, ref processed);
                    break;
                case "Histogram":
                    global::DIP.Histogram(ref loaded, ref processed);
                    break;
                case "Sepia":
                    global::DIP.Sepia(ref loaded, ref processed);
                    break;
                case "Brightness":
                    global::DIP.Brightness(ref loaded, ref processed, trackBar1.Value);
                    break;
                case "Contrast":
                    global::DIP.Contrast(ref loaded, ref processed, trackBar2.Value);
                    break;
                case "Rotation":
                    global::DIP.Rotation(ref loaded, ref processed, trackBar3.Value);
                    break;
                case "Threshold":
                    global::DIP.Threshold(ref loaded, ref processed, trackBar4.Value);
                    break;
                case "Smoothing":
                    processed = (Bitmap)loaded.Clone(); ;
                    BitmapFilter.Smooth(processed);
                    break;
                case "GaussianBlur":
                    processed = (Bitmap)loaded.Clone(); ;
                    BitmapFilter.GaussianBlur(processed);
                    break;
                case "Sharpen":
                    processed = (Bitmap)loaded.Clone(); ;
                    BitmapFilter.Sharpen(processed);
                    break;
                case "Mean Removal":
                    processed = (Bitmap)loaded.Clone(); ;
                    BitmapFilter.MeanRemoval(processed);
                    break;
                case "Embossing Laplascian":
                    processed = (Bitmap)loaded.Clone(); ;
                    BitmapFilter.EmbossLaplacian(processed);
                    break;
                case "Embossing Vertical Horizontal":
                    processed = (Bitmap)loaded.Clone();
                    BitmapFilter.GaussianBlur(processed);
                    break;
                case "Embossing All Directions":
                    processed = (Bitmap)loaded.Clone(); ;
                    BitmapFilter.EmbossAllDirections(processed);
                    break;
                case "Embossing Lossy":
                    processed = (Bitmap)loaded.Clone(); ;
                    BitmapFilter.EmbossLossy(processed);
                    break;
                case "Embossing Horizontal":
                    processed = (Bitmap)loaded.Clone(); ;
                    BitmapFilter.EmbossHorizontal(processed);
                    break;
                case "Embossing Vertical":
                    processed = (Bitmap)loaded.Clone(); ;
                    BitmapFilter.EmbossVertical(processed);
                    break;
                case "Subtract":
                    Bitmap a = (Bitmap)SubtractPic1.Image;
                    Bitmap b = (Bitmap)SubtractPic2.Image;
                    a = DIP.ResizeImage(a, b);
                    Bitmap c = new Bitmap(a.Width, a.Height);
                    global::DIP.Subtract(ref a, ref b, ref c, subtractColor);
                    SubtractPic3.Image = c;
                    return;
            }
            pictureBox2.Image = processed;
        }

        private async void PixelCopy(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "PixelCopy";
                timer1.Start();
            }
            else
            {
                global::DIP.PixelCopy(ref loaded, ref processed);
                pictureBox2.Image = processed;
            }
        }

        private void Greyscale(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Greyscale";
                timer1.Start();
            }
            else
            {
                global::DIP.Greyscale(ref loaded, ref processed);
                pictureBox2.Image = processed;
            }
        }

        private void ColorInversion(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Color Inversion";
                timer1.Start();
            }
            else
            {
                global::DIP.ColorInversion(ref loaded, ref processed);
                pictureBox2.Image = processed;
            }
        }

        private void MirrorHorizontal(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Mirror Horizontal";
                timer1.Start();
            }
            else
            {
                global::DIP.MirrorHorizontal(ref loaded, ref processed);
                pictureBox2.Image = processed;
            }
        }
        private void MirrorVertical(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Mirror Vertical";
                timer1.Start();
            }
            else
            {
                global::DIP.MirrorVertical(ref loaded, ref processed);
                pictureBox2.Image = processed;
            }
        }

        private void Histogram(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Histogram";
                timer1.Start();
            }
            else
            {
                global::DIP.Histogram(ref loaded, ref processed);
                pictureBox2.Image = processed;
            }
        }

        private void Brightness(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Brightness";
                timer1.Start();
            }
            else
            {
                global::DIP.Brightness(ref loaded, ref processed, trackBar1.Value);
                pictureBox2.Image = processed;
            }
        }

        private void Contrast(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Contrast";
                timer1.Start();
            }
            else
            {
                global::DIP.Contrast(ref loaded, ref processed, trackBar2.Value);
                pictureBox2.Image = processed;
            }
        }

        public unsafe void Rotation(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Rotation";
                timer1.Start();
            }
            else
            {
                global::DIP.Rotation(ref loaded, ref processed, trackBar3.Value);
                pictureBox2.Image = processed;
            }
        }

        public unsafe void Sepia(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Sepia";
                timer1.Start();
            }
            else
            {
                global::DIP.Sepia(ref loaded, ref processed);
                pictureBox2.Image = processed;
            }
        }
        private void Subtract(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Subtract";
                timer1.Start();
            }
            else
            {
                Bitmap a = (Bitmap)SubtractPic1.Image;
                Bitmap b = (Bitmap)SubtractPic2.Image;
                a = DIP.ResizeImage(a, b);

                Bitmap c = new Bitmap(a.Width, a.Height);

                global::DIP.Subtract(ref a, ref b, ref c, subtractColor);
                SubtractPic3.Image = c;
            }
        }

        private void Threshold(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Threshold";
                timer1.Start();
            }
            else
            {
                global::DIP.Threshold(ref loaded, ref processed, trackBar4.Value);
                pictureBox2.Image = processed;
            }

        }
        private void Smoothing(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Smoothing";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.Smooth(processed);
                pictureBox2.Image = processed;
            }
        }
        private void GaussianBlur(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "GaussianBlur";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.GaussianBlur(processed);
                pictureBox2.Image = processed;
            }
        }
        private void Sharpen(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Sharpen";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.Sharpen(processed);
                pictureBox2.Image = processed;
            }
        }

        private void MeanRemoval(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Mean Removal";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.MeanRemoval(processed);
                pictureBox2.Image = processed;
            }
        }

        private void EmbossingLaplascian(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Embossing Laplascian";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.EmbossLaplacian(processed);
                pictureBox2.Image = processed;
            }
        }
        private void EmbossingHorizontalVertical(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Embossing Vertical Horizontal";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.EmbossVerticalHorizontal(processed);
                pictureBox2.Image = processed;
            }
        }

        private void EmbossingAllDirections(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Embossing All Directions";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.EmbossAllDirections(processed);
                pictureBox2.Image = processed;
            }

        }

        private void EmbossingLossy(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Embossing Lossy";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.EmbossLossy(processed);
                pictureBox2.Image = processed;
            }
        }

        private void EmbossingHorizontal(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Embossing Horizontal";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.EmbossHorizontal(processed);
                pictureBox2.Image = processed;
            }

        }

        private void EmbossingVertical(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            if (webcam)
            {
                webcamDIPMode = "Embossing Vertical";
                timer1.Start();
            }
            else
            {
                processed = (Bitmap)loaded.Clone(); ;
                BitmapFilter.EmbossVertical(processed);
                pictureBox2.Image = processed;
            }
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
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialogSubtractImageA.ShowDialog();
        }
        private void openFileDialogSubtractImageA_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SubtractPic1.Image = new Bitmap(openFileDialogSubtractImageA.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialogSubtractImageB.ShowDialog();
        }

        private void openFileDialogSubtractImageB_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SubtractPic2.Image = new Bitmap(openFileDialogSubtractImageB.FileName);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialogCoins.ShowDialog();
        }

        private void openFileDialogCoins_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pictureBoxCoins.Image = new Bitmap(openFileDialogCoins.FileName);
            coins = new Bitmap(openFileDialogCoins.FileName);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSubtractColor.BackColor = colorDialog1.Color;
                subtractColor = colorDialog1.Color;
            }
        }

        private void Vcd_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = frame;
            SubtractPic1.Image = frame;
        }

        private void stopCamera()
        {
            vcd.SignalToStop();
            vcd.WaitForStop();
        }

        private void useCamera()
        {
            if (checkBox1.Checked)
            {
                webcam = true;
                stopCamera();
                vcd = new VideoCaptureDevice(fic[comboBox1.SelectedIndex].MonikerString);
                vcd.NewFrame += Vcd_NewFrame;
                vcd.Start();
            }
            else
            {
                webcam = false;
                stopCamera();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            useCamera();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            useCamera();
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

        private void CountCoins(object sender, EventArgs e)
        {
            //processed = (Bitmap)loaded.Clone();

            //Bitmap b = DIP.GrayScale(loaded);
            //b = ConvolutionMatrix.GaussianBlur(b);
            //b = ConvolutionMatrix.EdgeDetect(b, 160);
            //b = DIP.MedianFilter(b, 3);
            //b = ConvolutionMatrix.Dilation(b);
            //b = ConvolutionMatrix.Erosion(b);
            //b = DIP.MedianFilter(b, 3);
            //b = DIP.MedianFilter(b, 3);
            //b = DIP.MedianFilter(b, 3);
            //pictureBox2.Image = b;


            //Tuple<List<List<Point>>, List<int>, List<double>> t = CoinCounter.CountCoins(Utils.TraceContours(b));
            //List<List<Point>> coins;
            //List<int> coinValues;
            ////List<double> coinSizes;

            //coins = t.Item1;
            //coinValues = t.Item2;
            ////coinSizes = t.Item3;
            //int valSum = coinValues.Sum();

            //Debug.WriteLine("Coins found: " + coins.Count);

            //Debug.WriteLine(valSum / 100 + " Peso and " + valSum % 100 + " Cents");

            //Bitmap contourImage = new Bitmap(loaded);
            //foreach (var contour in coins)
            //{
            //    foreach (var point in contour)
            //    {
            //        contourImage.SetPixel(point.X, point.Y, Color.Red);
            //    }
            //}

            //pictureBox2.Image = contourImage;

            Bitmap bmresult = new Bitmap(pictureBoxCoins.Image);
            global::DIP.Threshold(ref coins, ref bmresult, 200);

            var visited = new bool[coins.Width, coins.Height];
            var objects = new List<List<Point>>();

            for (int y = 0; y < bmresult.Height; y++)
                for (int x = 0; x < bmresult.Width; x++)
                    if (bmresult.GetPixel(x, y).R == 0 && !visited[x, y])
                    {
                        var points = new List<Point>();
                        Fill(bmresult, x, y, visited, 20, points);
                        if (points.Count > 6500)
                            objects.Add(points);
                    }

            var coinCounts = new Dictionary<double, int>();
            var totalCoins = 0;
            var totalValue = 0.0;

            foreach (var points in objects)
            {
                points.ForEach(p => bmresult.SetPixel(p.X, p.Y, Color.Red));

                double value = points.Count switch
                {
                    > 18000 => 5.00,
                    > 15000 => 1.00,
                    > 11000 => 0.25,
                    > 8000 => 0.10,
                    _ => 0.05
                };

                coinCounts[value] = coinCounts.GetValueOrDefault(value) + 1;
                totalCoins++;
                totalValue += value;
            }

            var result = $"Coins found: {totalCoins}\n" +
                        $"Total value: {totalValue:F2}\n" +
                        string.Join("\n", coinCounts
                            .OrderByDescending(kvp => kvp.Key)
                            .Select(kvp => $"{kvp.Key:F2} x {kvp.Value} = {kvp.Key * kvp.Value:F2}"));

            pictureBoxCoinsResult.Image = bmresult;
            MessageBox.Show(result);
        }

        static void Fill(Bitmap image, int startX, int startY, bool[,] visited, int threshold, List<Point> points)
        {
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(startX, startY));
            visited[startX, startY] = true;

            while (stack.Count > 0)
            {
                Point p = stack.Pop();
                Color neighborColor;

                points.Add(p);

                for (int dy = -1; dy <= 1; dy++)
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        int nx = p.X + dx;
                        int ny = p.Y + dy;

                        if (nx >= 0 && ny >= 0 && nx < image.Width && ny < image.Height && !visited[nx, ny])
                        {
                            neighborColor = image.GetPixel(nx, ny);
                            if (neighborColor.R < threshold)
                            {
                                visited[nx, ny] = true;
                                stack.Push(new Point(nx, ny));
                            }
                        }
                    }
                }
            }
        }

    }
}
