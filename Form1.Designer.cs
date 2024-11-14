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
            components = new System.ComponentModel.Container();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            trackBar2 = new TrackBar();
            label2 = new Label();
            trackBar3 = new TrackBar();
            pictureBox3 = new PictureBox();
            openFileDialog2 = new OpenFileDialog();
            label3 = new Label();
            trackBar4 = new TrackBar();
            label5 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
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
            menuStrip1 = new MenuStrip();
            convolutionMatrixToolStripMenuItem = new ToolStripMenuItem();
            smoothingToolStripMenuItem1 = new ToolStripMenuItem();
            gaussianBlurToolStripMenuItem = new ToolStripMenuItem();
            sharpenToolStripMenuItem = new ToolStripMenuItem();
            meanRemovalToolStripMenuItem = new ToolStripMenuItem();
            embossingToolStripMenuItem = new ToolStripMenuItem();
            embossingHorVertToolStripMenuItem = new ToolStripMenuItem();
            embossingAllDirectionsToolStripMenuItem = new ToolStripMenuItem();
            embossingLossyToolStripMenuItem = new ToolStripMenuItem();
            embossingHorizontalToolStripMenuItem = new ToolStripMenuItem();
            embossingVerticalToolStripMenuItem = new ToolStripMenuItem();
            coinsToolStripMenuItem = new ToolStripMenuItem();
            countToolStripMenuItem = new ToolStripMenuItem();
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
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
            pictureBox1.Location = new Point(10, 49);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(525, 420);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(558, 49);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(525, 420);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 505);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "Brightness";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(10, 584);
            trackBar2.Margin = new Padding(3, 2, 3, 2);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(1029, 45);
            trackBar2.TabIndex = 5;
            trackBar2.Scroll += Contrast;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 566);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 6;
            label2.Text = "Contrast";
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(10, 645);
            trackBar3.Margin = new Padding(3, 2, 3, 2);
            trackBar3.Maximum = 360;
            trackBar3.Minimum = -360;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(1029, 45);
            trackBar3.TabIndex = 7;
            trackBar3.Scroll += Rotation;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(1111, 49);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(525, 420);
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
            label3.Location = new Point(10, 628);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 9;
            label3.Text = "Rotation";
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(10, 706);
            trackBar4.Margin = new Padding(3, 2, 3, 2);
            trackBar4.Maximum = 200;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(1029, 45);
            trackBar4.TabIndex = 10;
            trackBar4.Scroll += Threshold;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 689);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 12;
            label5.Text = "Threshold";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem1, openBackgroundToolStripMenuItem, saveToolStripMenuItem });
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(37, 20);
            openToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            openToolStripMenuItem1.Size = new Size(170, 22);
            openToolStripMenuItem1.Text = "Open";
            openToolStripMenuItem1.Click += openToolStripMenuItem1_Click;
            // 
            // openBackgroundToolStripMenuItem
            // 
            openBackgroundToolStripMenuItem.Name = "openBackgroundToolStripMenuItem";
            openBackgroundToolStripMenuItem.Size = new Size(170, 22);
            openBackgroundToolStripMenuItem.Text = "Open Background";
            openBackgroundToolStripMenuItem.Click += openBackgroundToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(170, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // dIPToolStripMenuItem
            // 
            dIPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pixelCopyToolStripMenuItem, greyscalingToolStripMenuItem, inversionToolStripMenuItem, mirrorHorizontalToolStripMenuItem, mirrorVerticalToolStripMenuItem, histogramToolStripMenuItem, sepiaToolStripMenuItem, subtractToolStripMenuItem });
            dIPToolStripMenuItem.Name = "dIPToolStripMenuItem";
            dIPToolStripMenuItem.Size = new Size(37, 20);
            dIPToolStripMenuItem.Text = "DIP";
            // 
            // pixelCopyToolStripMenuItem
            // 
            pixelCopyToolStripMenuItem.Name = "pixelCopyToolStripMenuItem";
            pixelCopyToolStripMenuItem.Size = new Size(165, 22);
            pixelCopyToolStripMenuItem.Text = "Pixel Copy";
            pixelCopyToolStripMenuItem.Click += PixelCopy;
            // 
            // greyscalingToolStripMenuItem
            // 
            greyscalingToolStripMenuItem.Name = "greyscalingToolStripMenuItem";
            greyscalingToolStripMenuItem.Size = new Size(165, 22);
            greyscalingToolStripMenuItem.Text = "Greyscaling";
            greyscalingToolStripMenuItem.Click += Greyscale;
            // 
            // inversionToolStripMenuItem
            // 
            inversionToolStripMenuItem.Name = "inversionToolStripMenuItem";
            inversionToolStripMenuItem.Size = new Size(165, 22);
            inversionToolStripMenuItem.Text = "Inversion";
            inversionToolStripMenuItem.Click += ColorInversion;
            // 
            // mirrorHorizontalToolStripMenuItem
            // 
            mirrorHorizontalToolStripMenuItem.Name = "mirrorHorizontalToolStripMenuItem";
            mirrorHorizontalToolStripMenuItem.Size = new Size(165, 22);
            mirrorHorizontalToolStripMenuItem.Text = "Mirror Horizontal";
            mirrorHorizontalToolStripMenuItem.Click += MirrorHorizontal;
            // 
            // mirrorVerticalToolStripMenuItem
            // 
            mirrorVerticalToolStripMenuItem.Name = "mirrorVerticalToolStripMenuItem";
            mirrorVerticalToolStripMenuItem.Size = new Size(165, 22);
            mirrorVerticalToolStripMenuItem.Text = "Mirror Vertical";
            mirrorVerticalToolStripMenuItem.Click += MirrorVertical;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(165, 22);
            histogramToolStripMenuItem.Text = "Histogram";
            histogramToolStripMenuItem.Click += Histogram;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(165, 22);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += Sepia;
            // 
            // subtractToolStripMenuItem
            // 
            subtractToolStripMenuItem.Name = "subtractToolStripMenuItem";
            subtractToolStripMenuItem.Size = new Size(165, 22);
            subtractToolStripMenuItem.Text = "Subtract";
            subtractToolStripMenuItem.Click += Subtract;
            // 
            // webcamToolStripMenuItem
            // 
            webcamToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { devicesToolStripMenuItem, offToolStripMenuItem });
            webcamToolStripMenuItem.Name = "webcamToolStripMenuItem";
            webcamToolStripMenuItem.Size = new Size(66, 20);
            webcamToolStripMenuItem.Text = "Webcam";
            // 
            // devicesToolStripMenuItem
            // 
            devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
            devicesToolStripMenuItem.Size = new Size(114, 22);
            devicesToolStripMenuItem.Text = "Devices";
            // 
            // offToolStripMenuItem
            // 
            offToolStripMenuItem.Name = "offToolStripMenuItem";
            offToolStripMenuItem.Size = new Size(114, 22);
            offToolStripMenuItem.Text = "Off";
            offToolStripMenuItem.Click += offToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, dIPToolStripMenuItem, webcamToolStripMenuItem, convolutionMatrixToolStripMenuItem, coinsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1664, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // convolutionMatrixToolStripMenuItem
            // 
            convolutionMatrixToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { smoothingToolStripMenuItem1, gaussianBlurToolStripMenuItem, sharpenToolStripMenuItem, meanRemovalToolStripMenuItem, embossingToolStripMenuItem, embossingHorVertToolStripMenuItem, embossingAllDirectionsToolStripMenuItem, embossingLossyToolStripMenuItem, embossingHorizontalToolStripMenuItem, embossingVerticalToolStripMenuItem });
            convolutionMatrixToolStripMenuItem.Name = "convolutionMatrixToolStripMenuItem";
            convolutionMatrixToolStripMenuItem.Size = new Size(122, 20);
            convolutionMatrixToolStripMenuItem.Text = "Convolution Matrix";
            // 
            // smoothingToolStripMenuItem1
            // 
            smoothingToolStripMenuItem1.Name = "smoothingToolStripMenuItem1";
            smoothingToolStripMenuItem1.Size = new Size(205, 22);
            smoothingToolStripMenuItem1.Text = "Smoothing";
            smoothingToolStripMenuItem1.Click += Smoothing;
            // 
            // gaussianBlurToolStripMenuItem
            // 
            gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
            gaussianBlurToolStripMenuItem.Size = new Size(205, 22);
            gaussianBlurToolStripMenuItem.Text = "Gaussian Blur";
            gaussianBlurToolStripMenuItem.Click += GaussianBlur;
            // 
            // sharpenToolStripMenuItem
            // 
            sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            sharpenToolStripMenuItem.Size = new Size(205, 22);
            sharpenToolStripMenuItem.Text = "Sharpen";
            sharpenToolStripMenuItem.Click += Sharpen;
            // 
            // meanRemovalToolStripMenuItem
            // 
            meanRemovalToolStripMenuItem.Name = "meanRemovalToolStripMenuItem";
            meanRemovalToolStripMenuItem.Size = new Size(205, 22);
            meanRemovalToolStripMenuItem.Text = "Mean Removal";
            meanRemovalToolStripMenuItem.Click += MeanRemoval;
            // 
            // embossingToolStripMenuItem
            // 
            embossingToolStripMenuItem.Name = "embossingToolStripMenuItem";
            embossingToolStripMenuItem.Size = new Size(205, 22);
            embossingToolStripMenuItem.Text = "Embossing Laplascian";
            embossingToolStripMenuItem.Click += EmbossingLaplascian;
            // 
            // embossingHorVertToolStripMenuItem
            // 
            embossingHorVertToolStripMenuItem.Name = "embossingHorVertToolStripMenuItem";
            embossingHorVertToolStripMenuItem.Size = new Size(205, 22);
            embossingHorVertToolStripMenuItem.Text = "Embossing Hor/Vert";
            embossingHorVertToolStripMenuItem.Click += EmbossingHorizontalVertical;
            // 
            // embossingAllDirectionsToolStripMenuItem
            // 
            embossingAllDirectionsToolStripMenuItem.Name = "embossingAllDirectionsToolStripMenuItem";
            embossingAllDirectionsToolStripMenuItem.Size = new Size(205, 22);
            embossingAllDirectionsToolStripMenuItem.Text = "Embossing All Directions";
            embossingAllDirectionsToolStripMenuItem.Click += EmbossingAllDirections;
            // 
            // embossingLossyToolStripMenuItem
            // 
            embossingLossyToolStripMenuItem.Name = "embossingLossyToolStripMenuItem";
            embossingLossyToolStripMenuItem.Size = new Size(205, 22);
            embossingLossyToolStripMenuItem.Text = "Embossing Lossy";
            embossingLossyToolStripMenuItem.Click += EmbossingLossy;
            // 
            // embossingHorizontalToolStripMenuItem
            // 
            embossingHorizontalToolStripMenuItem.Name = "embossingHorizontalToolStripMenuItem";
            embossingHorizontalToolStripMenuItem.Size = new Size(205, 22);
            embossingHorizontalToolStripMenuItem.Text = "Embossing Horizontal";
            embossingHorizontalToolStripMenuItem.Click += EmbossingHorizontal;
            // 
            // embossingVerticalToolStripMenuItem
            // 
            embossingVerticalToolStripMenuItem.Name = "embossingVerticalToolStripMenuItem";
            embossingVerticalToolStripMenuItem.Size = new Size(205, 22);
            embossingVerticalToolStripMenuItem.Text = "Embossing Vertical";
            embossingVerticalToolStripMenuItem.Click += EmbossingVertical;
            // 
            // coinsToolStripMenuItem
            // 
            coinsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { countToolStripMenuItem });
            coinsToolStripMenuItem.Name = "coinsToolStripMenuItem";
            coinsToolStripMenuItem.Size = new Size(49, 20);
            coinsToolStripMenuItem.Text = "Coins";
            // 
            // countToolStripMenuItem
            // 
            countToolStripMenuItem.Name = "countToolStripMenuItem";
            countToolStripMenuItem.Size = new Size(107, 22);
            countToolStripMenuItem.Text = "Count";
            countToolStripMenuItem.Click += countToolStripMenuItem_Click_1;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(10, 522);
            trackBar1.Margin = new Padding(3, 2, 3, 2);
            trackBar1.Maximum = 255;
            trackBar1.Minimum = -50;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(1029, 45);
            trackBar1.TabIndex = 3;
            trackBar1.Scroll += Brightness;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1664, 775);
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
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(1682, 820);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Minimized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private TrackBar trackBar2;
        private Label label2;
        private TrackBar trackBar3;
        private ToolStripMenuItem onToolStripMenuItem1;
        private PictureBox pictureBox3;
        private OpenFileDialog openFileDialog2;
        private Label label3;
        private TrackBar trackBar4;
        private Label label5;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem1;
        private ToolStripMenuItem openBackgroundToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem dIPToolStripMenuItem;
        private ToolStripMenuItem pixelCopyToolStripMenuItem;
        private ToolStripMenuItem greyscalingToolStripMenuItem;
        private ToolStripMenuItem inversionToolStripMenuItem;
        private ToolStripMenuItem mirrorHorizontalToolStripMenuItem;
        private ToolStripMenuItem mirrorVerticalToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private ToolStripMenuItem subtractToolStripMenuItem;
        private ToolStripMenuItem webcamToolStripMenuItem;
        private ToolStripMenuItem devicesToolStripMenuItem;
        private ToolStripMenuItem offToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem convolutionMatrixToolStripMenuItem;
        private ToolStripMenuItem smoothingToolStripMenuItem1;
        private ToolStripMenuItem gaussianBlurToolStripMenuItem;
        private ToolStripMenuItem sharpenToolStripMenuItem;
        private ToolStripMenuItem meanRemovalToolStripMenuItem;
        private ToolStripMenuItem embossingToolStripMenuItem;
        private ToolStripMenuItem embossingHorVertToolStripMenuItem;
        private ToolStripMenuItem embossingAllDirectionsToolStripMenuItem;
        private ToolStripMenuItem embossingLossyToolStripMenuItem;
        private ToolStripMenuItem embossingHorizontalToolStripMenuItem;
        private ToolStripMenuItem embossingVerticalToolStripMenuItem;
        private ToolStripMenuItem coinsToolStripMenuItem;
        private ToolStripMenuItem countToolStripMenuItem;
        private TrackBar trackBar1;
    }
}
