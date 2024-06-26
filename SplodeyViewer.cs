using Swed64;

namespace splodey_next
{
    public partial class SplodeyViewer : Form
    {
        private Swed processHandler { get; set; }
        private Thread readThread;
        private bool startReading = false;
        private Bitmap LevelImage;
        private Bitmap LevelImageBuffer;

        public SplodeyViewer()
        {
            InitializeComponent();
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
                            Invoke(new Action(() =>
                            {
                                current_level.Text = $"Current Room ID: {room_id.ToString()}";
                                debug_text.Text = "";
                            }));

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
                            // tell the user that the image is missing. Some missing images are intentional, though.
                            Invoke(new Action(() =>
                            {
                                debug_text.Text = @$"Couldn't find LevelImages\{room_id}.png";
                            }));
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception)
            {
                // Can't read game's memory. Either the game was closed or 
                Invoke(new Action(() =>
                {
                    current_level.Text = "Failed to read Splodey's memory.";
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }));
                startReading = false;

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (readThread == null || !readThread.IsAlive)
            {
                // attempt to attach game process
                try
                {
                    processHandler = new Swed("Splodey");
                    startReading = true;
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    readThread = new Thread(ReadRoomID);
                    readThread.IsBackground = true;
                    readThread.Start();
                }
                catch (Exception ex)
                {
                    startReading = false;
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    current_level.Text = "Couldn't find Splodey process.";
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            startReading = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            current_level.Text = "Stopped.";
            if (readThread != null && readThread.IsAlive)
            {
                readThread.Join();
            }
        }

        private void checkOnTop_CheckedChanged(object sender, EventArgs e)
        {
            Form.ActiveForm.TopMost = checkOnTop.Checked;
        }
    }
}
