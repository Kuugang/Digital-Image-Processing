using System.Drawing;
using System.Drawing.Imaging;
using Image_Processing.WebCamLib;

namespace Image_Processing
{
    public unsafe partial class Form1 : Form
    {
        private Bitmap loaded, processed;

        private Boolean webcam = false;
        private int webcamIndex;
        private String webcamDIPMode;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private Boolean GetBitmaps()
        {
            if (webcam)
                loaded = DeviceManager.GetDevice(webcamIndex).GetFrame();
            else
                loaded = (Bitmap)pictureBox1.Image;
            if (loaded == null)
            {
                return false;
            }
            processed = new Bitmap(loaded.Width, loaded.Height);
            return true;
        }
        private bool shouldContinueProcessing = true;
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
                    DIP.PixelCopy(ref loaded, ref processed);
                    break;
                case "Greyscale":
                    DIP.Greyscale(ref loaded, ref processed);
                    break;
                case "Color Inversion":
                    DIP.ColorInversion(ref loaded, ref processed);
                    break;
                case "Mirror Horizontal":
                    DIP.MirrorHorizontal(ref loaded, ref processed);
                    break;
                case "Mirror Vertical":
                    DIP.MirrorVertical(ref loaded, ref processed);
                    break;
                case "Histogram":
                    DIP.Histogram(ref loaded, ref processed);
                    break;
                case "Sepia":
                    DIP.Sepia(ref loaded, ref processed);
                    break;
                case "Brightness":
                    DIP.Brightness(ref loaded, ref processed, trackBar1.Value);
                    break;
                case "Contrast":
                    DIP.Contrast(ref loaded, ref processed, trackBar2.Value);
                    break;
                case "Rotation":
                    DIP.Rotation(ref loaded, ref processed, trackBar3.Value);
                    break;
                case "Threshold":
                    DIP.Threshold(ref loaded, ref processed, trackBar4.Value);
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
                DIP.PixelCopy(ref loaded, ref processed);
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
                DIP.Greyscale(ref loaded, ref processed);
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
                DIP.ColorInversion(ref loaded, ref processed);
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
                DIP.MirrorHorizontal(ref loaded, ref processed);
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
                DIP.MirrorVertical(ref loaded, ref processed);
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
                DIP.Histogram(ref loaded, ref processed);
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
                DIP.Brightness(ref loaded, ref processed, trackBar1.Value);
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
                DIP.Contrast(ref loaded, ref processed, trackBar2.Value);
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
                DIP.Rotation(ref loaded, ref processed, trackBar3.Value);
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
                DIP.Sepia(ref loaded, ref processed);
                pictureBox2.Image = processed;
            }
        }
        private void Subtract(object sender, EventArgs e)
        {
            if (!this.GetBitmaps()) return;
            //if (webcam)
            //{
            //    TIRED
            //    webcamDIPMode = "Subtract";
            //    timer1.Start();
            //}
            //else
            //{
            Bitmap a = (Bitmap)pictureBox1.Image;
            Bitmap b = (Bitmap)pictureBox2.Image;

            DIP.Subtract(ref a, ref b, ref processed);
            pictureBox3.Image = processed;
            //}
            pictureBox3.Image = processed;
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
                DIP.Threshold(ref loaded, ref processed, trackBar4.Value);
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
