namespace splodey_next
{
    partial class SplodeyViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplodeyViewer));
            imageList1 = new ImageList(components);
            levelPicture = new PictureBox();
            current_level = new Label();
            btnStop = new Button();
            btnStart = new Button();
            label1 = new Label();
            checkOnTop = new CheckBox();
            debug_text = new Label();
            ((System.ComponentModel.ISupportInitialize)levelPicture).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // levelPicture
            // 
            levelPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            levelPicture.Location = new Point(12, 31);
            levelPicture.Name = "levelPicture";
            levelPicture.Size = new Size(814, 496);
            levelPicture.SizeMode = PictureBoxSizeMode.Zoom;
            levelPicture.TabIndex = 0;
            levelPicture.TabStop = false;
            // 
            // current_level
            // 
            current_level.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            current_level.AutoSize = true;
            current_level.Location = new Point(12, 550);
            current_level.Name = "current_level";
            current_level.Size = new Size(54, 15);
            current_level.TabIndex = 1;
            current_level.Text = "Stopped.";
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStop.Enabled = false;
            btnStop.Location = new Point(745, 546);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStart.Location = new Point(664, 546);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "NEXT:";
            // 
            // checkOnTop
            // 
            checkOnTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkOnTop.AutoSize = true;
            checkOnTop.Location = new Point(557, 549);
            checkOnTop.Name = "checkOnTop";
            checkOnTop.Size = new Size(101, 19);
            checkOnTop.TabIndex = 5;
            checkOnTop.Text = "Always on top";
            checkOnTop.UseVisualStyleBackColor = true;
            checkOnTop.CheckedChanged += checkOnTop_CheckedChanged;
            // 
            // debug_text
            // 
            debug_text.AutoSize = true;
            debug_text.Dock = DockStyle.Right;
            debug_text.Location = new Point(832, 0);
            debug_text.Name = "debug_text";
            debug_text.RightToLeft = RightToLeft.Yes;
            debug_text.Size = new Size(0, 15);
            debug_text.TabIndex = 6;
            debug_text.TextAlign = ContentAlignment.MiddleRight;
            // 
            // SplodeyViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 581);
            Controls.Add(debug_text);
            Controls.Add(checkOnTop);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Controls.Add(btnStop);
            Controls.Add(current_level);
            Controls.Add(levelPicture);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(480, 320);
            Name = "SplodeyViewer";
            Text = "Splodey Next Level Viewer v1.1.2";
            ((System.ComponentModel.ISupportInitialize)levelPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList imageList1;
        private PictureBox levelPicture;
        private Label current_level;
        private Button btnStop;
        private Button btnStart;
        private Label label1;
        private CheckBox checkOnTop;
        private Label debug_text;
    }
}
