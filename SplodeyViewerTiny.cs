using Swed64;

namespace SplodeyViewerTiny
{
    public partial class SplodeyViewerTiny : Form
    {
        private Point refPoint;
        private Point thisPoint;
        private bool dragging;

        private Swed processHandler { get; set; }
        private Thread readThread;
        private bool startReading = false;
        private Bitmap LevelImage;
        private Bitmap LevelImageBuffer;


        public SplodeyViewerTiny()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;


        }

        private void ReadRoomID()
        {
            try
            {
                nint baseAddr = 0;
                int room_id = 0;
                int old_room_id = 0;


                while (startReading)
                {
                    baseAddr = processHandler.GetModuleBase("Splodey.exe");
                    room_id = processHandler.ReadInt(baseAddr, 0xC2C498); // For version 1.1.2
                    if (room_id != old_room_id)
                    {
                        try
                        {
                            old_room_id = room_id;

                            // Try to load the image first, it will throw an exception if it fails and won't Dispose the current image.
                            // Resizing the window with no image attached will throw an unhandled exception.
                            LevelImageBuffer = new Bitmap(Path.Combine(Environment.CurrentDirectory, @$"LevelImages\{room_id}.png"));

                            // Dispose image if there is one currently loaded.
                            if (LevelImage != null)
                            {
                                LevelImage.Dispose();
                            }

                            // Pass the buffer to the actual image variable
                            LevelImage = LevelImageBuffer;
                            // Display image.
                            levelPicture.Image = (Image)LevelImage;
                        }
                        catch (Exception)
                        {
                            // Do nothing. Some images missing are intentional.
                        }                        
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception)
            {
                // Can't read game's memory. Either the game was closed or doesn't have enough permissions.
                startReading = false;
                Invoke(new Action(() =>
                {
                    btnStart.Visible = true;
                    btnStart.Enabled = true;
                    debug_text.Visible = true;
                    debug_text.Text = "Error while reading Splodey's memory.";
                }));
            }
        }



        // stole this code somewhere lol sorry
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        private void levelPicture_MouseDown(object sender, MouseEventArgs e)
        {
            refPoint = Cursor.Position;
            thisPoint = Form.ActiveForm.Location;
            dragging = true;
        }

        private void levelPicture_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void levelPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(refPoint));
                this.Location = Point.Add(thisPoint, new Size(dif));
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.TopMost = true;
            if (readThread == null || !readThread.IsAlive)
            {
                // attempt to attach game process
                try
                {
                    processHandler = new Swed("Splodey");
                    btnStart.Visible = false;
                    btnStart.Enabled = false;
                    debug_text.Visible = false;
                    startReading = true;
                    readThread = new Thread(ReadRoomID);
                    readThread.IsBackground = true;
                    readThread.Start();
                }
                catch (Exception ex)
                {
                    startReading = false;
                    btnStart.Visible = true;
                    btnStart.Enabled = true;
                    debug_text.Visible = true;
                    debug_text.Text = "Couldn't find Splodey process.";
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }
    }
}
