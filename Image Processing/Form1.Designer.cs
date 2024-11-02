namespace Image_Processing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            openToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem1 = new ToolStripMenuItem();
            openBackgroundToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            dIPToolStripMenuItem = new ToolStripMenuItem();
            pixelCopyToolStripMenuItem = new ToolStripMenuItem();
            greyscalingToolStripMenuItem = new ToolStripMenuItem();
            inversionToolStripMenuItem = new ToolStripMenuItem();
            mirrorHorizontalToolStripMenuItem = new ToolStripMenuItem();
            mirrorVerticalToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            subtractToolStripMenuItem = new ToolStripMenuItem();
            webcamToolStripMenuItem = new ToolStripMenuItem();
            devicesToolStripMenuItem = new ToolStripMenuItem();
            offToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            trackBar1 = new TrackBar();
            label1 = new Label();
            trackBar2 = new TrackBar();
            label2 = new Label();
            trackBar3 = new TrackBar();
            pictureBox3 = new PictureBox();
            openFileDialog2 = new OpenFileDialog();
            label3 = new Label();
            trackBar4 = new TrackBar();
            label5 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, dIPToolStripMenuItem, webcamToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1902, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem1, openBackgroundToolStripMenuItem, saveToolStripMenuItem });
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(46, 24);
            openToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            openToolStripMenuItem1.Size = new Size(211, 26);
            openToolStripMenuItem1.Text = "Open";
            openToolStripMenuItem1.Click += openToolStripMenuItem1_Click;
            // 
            // openBackgroundToolStripMenuItem
            // 
            openBackgroundToolStripMenuItem.Name = "openBackgroundToolStripMenuItem";
            openBackgroundToolStripMenuItem.Size = new Size(211, 26);
            openBackgroundToolStripMenuItem.Text = "Open Background";
            openBackgroundToolStripMenuItem.Click += openBackgroundToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(211, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // dIPToolStripMenuItem
            // 
            dIPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pixelCopyToolStripMenuItem, greyscalingToolStripMenuItem, inversionToolStripMenuItem, mirrorHorizontalToolStripMenuItem, mirrorVerticalToolStripMenuItem, histogramToolStripMenuItem, sepiaToolStripMenuItem, subtractToolStripMenuItem });
            dIPToolStripMenuItem.Name = "dIPToolStripMenuItem";
            dIPToolStripMenuItem.Size = new Size(46, 24);
            dIPToolStripMenuItem.Text = "DIP";
            // 
            // pixelCopyToolStripMenuItem
            // 
            pixelCopyToolStripMenuItem.Name = "pixelCopyToolStripMenuItem";
            pixelCopyToolStripMenuItem.Size = new Size(207, 26);
            pixelCopyToolStripMenuItem.Text = "Pixel Copy";
            pixelCopyToolStripMenuItem.Click += PixelCopy;
            // 
            // greyscalingToolStripMenuItem
            // 
            greyscalingToolStripMenuItem.Name = "greyscalingToolStripMenuItem";
            greyscalingToolStripMenuItem.Size = new Size(207, 26);
            greyscalingToolStripMenuItem.Text = "Greyscaling";
            greyscalingToolStripMenuItem.Click += Greyscale;
            // 
            // inversionToolStripMenuItem
            // 
            inversionToolStripMenuItem.Name = "inversionToolStripMenuItem";
            inversionToolStripMenuItem.Size = new Size(207, 26);
            inversionToolStripMenuItem.Text = "Inversion";
            inversionToolStripMenuItem.Click += ColorInversion;
            // 
            // mirrorHorizontalToolStripMenuItem
            // 
            mirrorHorizontalToolStripMenuItem.Name = "mirrorHorizontalToolStripMenuItem";
            mirrorHorizontalToolStripMenuItem.Size = new Size(207, 26);
            mirrorHorizontalToolStripMenuItem.Text = "Mirror Horizontal";
            mirrorHorizontalToolStripMenuItem.Click += MirrorHorizontal;
            // 
            // mirrorVerticalToolStripMenuItem
            // 
            mirrorVerticalToolStripMenuItem.Name = "mirrorVerticalToolStripMenuItem";
            mirrorVerticalToolStripMenuItem.Size = new Size(207, 26);
            mirrorVerticalToolStripMenuItem.Text = "Mirror Vertical";
            mirrorVerticalToolStripMenuItem.Click += MirrorVertical;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(207, 26);
            histogramToolStripMenuItem.Text = "Histogram";
            histogramToolStripMenuItem.Click += Histogram;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(207, 26);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += Sepia;
            // 
            // subtractToolStripMenuItem
            // 
            subtractToolStripMenuItem.Name = "subtractToolStripMenuItem";
            subtractToolStripMenuItem.Size = new Size(207, 26);
            subtractToolStripMenuItem.Text = "Subtract";
            subtractToolStripMenuItem.Click += Subtract;
            // 
            // webcamToolStripMenuItem
            // 
            webcamToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { devicesToolStripMenuItem, offToolStripMenuItem });
            webcamToolStripMenuItem.Name = "webcamToolStripMenuItem";
            webcamToolStripMenuItem.Size = new Size(81, 24);
            webcamToolStripMenuItem.Text = "Webcam";
            // 
            // devicesToolStripMenuItem
            // 
            devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
            devicesToolStripMenuItem.Size = new Size(143, 26);
            devicesToolStripMenuItem.Text = "Devices";
            // 
            // offToolStripMenuItem
            // 
            offToolStripMenuItem.Name = "offToolStripMenuItem";
            offToolStripMenuItem.Size = new Size(143, 26);
            offToolStripMenuItem.Text = "Off";
            offToolStripMenuItem.Click += offToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 560);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(638, 65);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(600, 560);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(12, 696);
            trackBar1.Maximum = 50;
            trackBar1.Minimum = -50;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(1176, 56);
            trackBar1.TabIndex = 3;
            trackBar1.Scroll += Brightness;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 673);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 4;
            label1.Text = "Brightness";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(12, 778);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(1176, 56);
            trackBar2.TabIndex = 5;
            trackBar2.Scroll += Contrast;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 755);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 6;
            label2.Text = "Contrast";
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(12, 860);
            trackBar3.Maximum = 360;
            trackBar3.Minimum = -360;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(1176, 56);
            trackBar3.TabIndex = 7;
            trackBar3.Scroll += Rotation;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(1270, 65);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(600, 560);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            openFileDialog2.FileOk += openFileDialog2_FileOk;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 837);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 9;
            label3.Text = "Rotation";
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(12, 942);
            trackBar4.Maximum = 200;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(1176, 56);
            trackBar4.TabIndex = 10;
            trackBar4.Scroll += Threshold;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 919);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 12;
            label5.Text = "Threshold";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label5);
            Controls.Add(trackBar4);
            Controls.Add(label3);
            Controls.Add(pictureBox3);
            Controls.Add(trackBar3);
            Controls.Add(label2);
            Controls.Add(trackBar2);
            Controls.Add(label1);
            Controls.Add(trackBar1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(1920, 1080);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem dIPToolStripMenuItem;
        private ToolStripMenuItem pixelCopyToolStripMenuItem;
        private ToolStripMenuItem greyscalingToolStripMenuItem;
        private ToolStripMenuItem inversionToolStripMenuItem;
        private ToolStripMenuItem mirrorHorizontalToolStripMenuItem;
        private ToolStripMenuItem mirrorVerticalToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private TrackBar trackBar1;
        private Label label1;
        private TrackBar trackBar2;
        private Label label2;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private TrackBar trackBar3;
        private ToolStripMenuItem webcamToolStripMenuItem;
        private ToolStripMenuItem devicesToolStripMenuItem;
        private ToolStripMenuItem onToolStripMenuItem1;
        private PictureBox pictureBox3;
        private ToolStripMenuItem openBackgroundToolStripMenuItem;
        private OpenFileDialog openFileDialog2;
        private ToolStripMenuItem offToolStripMenuItem;
        private ToolStripMenuItem subtractToolStripMenuItem;
        private Label label3;
        private TrackBar trackBar4;
        private Label label5;
    }
}
