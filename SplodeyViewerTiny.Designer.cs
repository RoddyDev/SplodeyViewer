namespace SplodeyViewerTiny
{
    partial class SplodeyViewerTiny
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplodeyViewerTiny));
            levelPicture = new PictureBox();
            debug_text = new Label();
            btnStart = new Button();
            ((System.ComponentModel.ISupportInitialize)levelPicture).BeginInit();
            SuspendLayout();
            // 
            // levelPicture
            // 
            levelPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            levelPicture.Location = new Point(4, 4);
            levelPicture.Name = "levelPicture";
            levelPicture.Size = new Size(792, 442);
            levelPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            levelPicture.TabIndex = 1;
            levelPicture.TabStop = false;
            levelPicture.MouseDown += levelPicture_MouseDown;
            levelPicture.MouseMove += levelPicture_MouseMove;
            levelPicture.MouseUp += levelPicture_MouseUp;
            // 
            // debug_text
            // 
            debug_text.AutoSize = true;
            debug_text.Location = new Point(16, 16);
            debug_text.Name = "debug_text";
            debug_text.Size = new Size(54, 15);
            debug_text.TabIndex = 2;
            debug_text.Text = "Stopped.";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(16, 34);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(72, 23);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // SplodeyViewerTiny
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStart);
            Controls.Add(debug_text);
            Controls.Add(levelPicture);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(80, 80);
            Name = "SplodeyViewerTiny";
            Text = "Splodey Next Level Viewer (Borderless) v1.1.2";
            ((System.ComponentModel.ISupportInitialize)levelPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox levelPicture;
        private Label debug_text;
        private Button btnStart;
    }
}
