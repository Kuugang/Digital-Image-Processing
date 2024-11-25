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
            openFileDialog2 = new OpenFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            trackBar4 = new TrackBar();
            label5 = new Label();
            trackBar3 = new TrackBar();
            label3 = new Label();
            trackBar2 = new TrackBar();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            trackBar1 = new TrackBar();
            pictureBox1 = new PictureBox();
            menuStrip2 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            dIPToolStripMenuItem = new ToolStripMenuItem();
            pixelCopyToolStripMenuItem = new ToolStripMenuItem();
            greyscalingToolStripMenuItem = new ToolStripMenuItem();
            inversionToolStripMenuItem = new ToolStripMenuItem();
            mirrorHorizontalToolStripMenuItem = new ToolStripMenuItem();
            mirrorVerticalToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            webcamToolStripMenuItem = new ToolStripMenuItem();
            devicesToolStripMenuItem = new ToolStripMenuItem();
            offToolStripMenuItem = new ToolStripMenuItem();
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
            tabPage2 = new TabPage();
            pictureBoxSubtractColor = new PictureBox();
            button6 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            SubtractPic3 = new PictureBox();
            SubtractPic2 = new PictureBox();
            SubtractPic1 = new PictureBox();
            tabPage3 = new TabPage();
            button5 = new Button();
            button4 = new Button();
            pictureBoxCoinsResult = new PictureBox();
            pictureBoxCoins = new PictureBox();
            openFileDialogSubtractImageA = new OpenFileDialog();
            openFileDialogSubtractImageB = new OpenFileDialog();
            openFileDialogCoins = new OpenFileDialog();
            colorDialog1 = new ColorDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip2.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSubtractColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubtractPic3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubtractPic2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubtractPic1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCoinsResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCoins).BeginInit();
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
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            openFileDialog2.FileOk += openFileDialog2_FileOk;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // tabControl1
            // 
            tabControl1.AccessibleName = "";
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(21, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(856, 582);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(checkBox1);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(trackBar4);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(trackBar3);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(trackBar2);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(pictureBox2);
            tabPage1.Controls.Add(trackBar1);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(menuStrip2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(848, 554);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "DIP";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(28, 510);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(95, 19);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "Use Webcam";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(128, 508);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 16;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(425, 438);
            trackBar4.Margin = new Padding(3, 2, 3, 2);
            trackBar4.Maximum = 200;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(400, 45);
            trackBar4.TabIndex = 14;
            trackBar4.Scroll += Threshold;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(425, 421);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 13;
            label5.Text = "Threshold";
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(425, 374);
            trackBar3.Margin = new Padding(3, 2, 3, 2);
            trackBar3.Maximum = 360;
            trackBar3.Minimum = -360;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(400, 45);
            trackBar3.TabIndex = 11;
            trackBar3.Scroll += Rotation;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(425, 357);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 10;
            label3.Text = "Rotation";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(19, 438);
            trackBar2.Margin = new Padding(3, 2, 3, 2);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(400, 45);
            trackBar2.TabIndex = 8;
            trackBar2.Scroll += Contrast;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 421);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 7;
            label2.Text = "Contrast";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 357);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 6;
            label1.Text = "Brightness";
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(454, 43);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(300, 300);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(19, 374);
            trackBar1.Margin = new Padding(3, 2, 3, 2);
            trackBar1.Maximum = 255;
            trackBar1.Minimum = -50;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(400, 45);
            trackBar1.TabIndex = 4;
            trackBar1.Scroll += Brightness;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(69, 43);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 300);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, dIPToolStripMenuItem, webcamToolStripMenuItem, convolutionMatrixToolStripMenuItem });
            menuStrip2.Location = new Point(3, 3);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(842, 24);
            menuStrip2.TabIndex = 15;
            menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(37, 20);
            toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(170, 22);
            toolStripMenuItem2.Text = "Open";
            toolStripMenuItem2.Click += openToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(170, 22);
            toolStripMenuItem3.Text = "Open Background";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(170, 22);
            toolStripMenuItem4.Text = "Save";
            toolStripMenuItem4.Click += saveToolStripMenuItem_Click;
            // 
            // dIPToolStripMenuItem
            // 
            dIPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pixelCopyToolStripMenuItem, greyscalingToolStripMenuItem, inversionToolStripMenuItem, mirrorHorizontalToolStripMenuItem, mirrorVerticalToolStripMenuItem, histogramToolStripMenuItem, sepiaToolStripMenuItem });
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
            // tabPage2
            // 
            tabPage2.Controls.Add(pictureBoxSubtractColor);
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(SubtractPic3);
            tabPage2.Controls.Add(SubtractPic2);
            tabPage2.Controls.Add(SubtractPic1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(848, 554);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Subtract";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBoxSubtractColor
            // 
            pictureBoxSubtractColor.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxSubtractColor.Location = new Point(744, 266);
            pictureBoxSubtractColor.Margin = new Padding(3, 2, 3, 2);
            pictureBoxSubtractColor.Name = "pictureBoxSubtractColor";
            pictureBoxSubtractColor.Size = new Size(30, 30);
            pictureBoxSubtractColor.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSubtractColor.TabIndex = 16;
            pictureBoxSubtractColor.TabStop = false;
            // 
            // button6
            // 
            button6.Location = new Point(634, 269);
            button6.Name = "button6";
            button6.Size = new Size(104, 23);
            button6.TabIndex = 15;
            button6.Text = "Select Color";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button3
            // 
            button3.Location = new Point(649, 233);
            button3.Name = "button3";
            button3.Size = new Size(104, 23);
            button3.TabIndex = 14;
            button3.Text = "Subtract";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Subtract;
            // 
            // button2
            // 
            button2.Location = new Point(363, 233);
            button2.Name = "button2";
            button2.Size = new Size(104, 23);
            button2.TabIndex = 13;
            button2.Text = "Load Image B";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(79, 233);
            button1.Name = "button1";
            button1.Size = new Size(104, 23);
            button1.TabIndex = 12;
            button1.Text = "Load Image A";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SubtractPic3
            // 
            SubtractPic3.BorderStyle = BorderStyle.FixedSingle;
            SubtractPic3.Location = new Point(573, 18);
            SubtractPic3.Margin = new Padding(3, 2, 3, 2);
            SubtractPic3.Name = "SubtractPic3";
            SubtractPic3.Size = new Size(245, 210);
            SubtractPic3.SizeMode = PictureBoxSizeMode.StretchImage;
            SubtractPic3.TabIndex = 11;
            SubtractPic3.TabStop = false;
            // 
            // SubtractPic2
            // 
            SubtractPic2.BorderStyle = BorderStyle.FixedSingle;
            SubtractPic2.Location = new Point(295, 18);
            SubtractPic2.Margin = new Padding(3, 2, 3, 2);
            SubtractPic2.Name = "SubtractPic2";
            SubtractPic2.Size = new Size(245, 210);
            SubtractPic2.SizeMode = PictureBoxSizeMode.StretchImage;
            SubtractPic2.TabIndex = 10;
            SubtractPic2.TabStop = false;
            // 
            // SubtractPic1
            // 
            SubtractPic1.BorderStyle = BorderStyle.FixedSingle;
            SubtractPic1.Location = new Point(19, 18);
            SubtractPic1.Margin = new Padding(3, 2, 3, 2);
            SubtractPic1.Name = "SubtractPic1";
            SubtractPic1.Size = new Size(245, 210);
            SubtractPic1.SizeMode = PictureBoxSizeMode.StretchImage;
            SubtractPic1.TabIndex = 9;
            SubtractPic1.TabStop = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(pictureBoxCoinsResult);
            tabPage3.Controls.Add(pictureBoxCoins);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(848, 554);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Coins";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(583, 327);
            button5.Name = "button5";
            button5.Size = new Size(104, 23);
            button5.TabIndex = 14;
            button5.Text = "Count";
            button5.UseVisualStyleBackColor = true;
            button5.Click += CountCoins;
            // 
            // button4
            // 
            button4.Location = new Point(157, 327);
            button4.Name = "button4";
            button4.Size = new Size(104, 23);
            button4.TabIndex = 13;
            button4.Text = "Load";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBoxCoinsResult
            // 
            pictureBoxCoinsResult.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCoinsResult.Location = new Point(483, 46);
            pictureBoxCoinsResult.Margin = new Padding(3, 2, 3, 2);
            pictureBoxCoinsResult.Name = "pictureBoxCoinsResult";
            pictureBoxCoinsResult.Size = new Size(301, 276);
            pictureBoxCoinsResult.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCoinsResult.TabIndex = 11;
            pictureBoxCoinsResult.TabStop = false;
            // 
            // pictureBoxCoins
            // 
            pictureBoxCoins.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCoins.Location = new Point(63, 46);
            pictureBoxCoins.Margin = new Padding(3, 2, 3, 2);
            pictureBoxCoins.Name = "pictureBoxCoins";
            pictureBoxCoins.Size = new Size(301, 276);
            pictureBoxCoins.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCoins.TabIndex = 10;
            pictureBoxCoins.TabStop = false;
            // 
            // openFileDialogSubtractImageA
            // 
            openFileDialogSubtractImageA.FileName = "openFileDialog3";
            openFileDialogSubtractImageA.FileOk += openFileDialogSubtractImageA_FileOk;
            // 
            // openFileDialogSubtractImageB
            // 
            openFileDialogSubtractImageB.FileName = "openFileDialog3";
            openFileDialogSubtractImageB.FileOk += openFileDialogSubtractImageB_FileOk;
            // 
            // openFileDialogCoins
            // 
            openFileDialogCoins.FileName = "openFileDialog3";
            openFileDialogCoins.FileOk += openFileDialogCoins_FileOk;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 636);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSubtractColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubtractPic3).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubtractPic2).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubtractPic1).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCoinsResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCoins).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem onToolStripMenuItem1;
        private OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Timer timer1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TrackBar trackBar4;
        private Label label5;
        private TrackBar trackBar3;
        private Label label3;
        private TrackBar trackBar2;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private TrackBar trackBar1;
        private PictureBox SubtractPic1;
        private MenuStrip menuStrip2;
        private PictureBox pictureBox1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem dIPToolStripMenuItem;
        private ToolStripMenuItem pixelCopyToolStripMenuItem;
        private ToolStripMenuItem greyscalingToolStripMenuItem;
        private ToolStripMenuItem inversionToolStripMenuItem;
        private ToolStripMenuItem mirrorHorizontalToolStripMenuItem;
        private ToolStripMenuItem mirrorVerticalToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private ToolStripMenuItem webcamToolStripMenuItem;
        private ToolStripMenuItem devicesToolStripMenuItem;
        private ToolStripMenuItem offToolStripMenuItem;
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
        private PictureBox SubtractPic3;
        private PictureBox SubtractPic2;
        private Button button3;
        private Button button2;
        private Button button1;
        private OpenFileDialog openFileDialogSubtractImageA;
        private OpenFileDialog openFileDialogSubtractImageB;
        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private Button button4;
        private PictureBox pictureBoxCoinsResult;
        private PictureBox pictureBoxCoins;
        private OpenFileDialog openFileDialogCoins;
        private Button button5;
        private PictureBox pictureBoxSubtractColor;
        private Button button6;
        private ColorDialog colorDialog1;
    }
}
