using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class SoundMediaTools : Form
    {
        public SoundMediaTools()
        {
            InitializeComponent();
            // Disable playback controls until a valid .wav file 
            // is selected.
            EnablePlaybackControls(false);

            // Set up the status bar and other controls.
            InitializeControls();

            // Set up the SoundPlayer object.
            InitializeSound();
        }

        DateTime lastTime;
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime lastTime2 = DateTime.Now;
            double diff = lastTime2.Subtract(lastTime).TotalMilliseconds;
            if (diff > 500)
            {
                (new Thread(() => System.Media.SystemSounds.Beep.Play())).Start();
            }
            lastTime = lastTime2;
            filepathTextbox.Text = "asdf";

        }

        private SoundPlayer player;

        // Sets up the status bar and other controls.
        private void InitializeControls()
        {


        }
        // Sets up the SoundPlayer object.
        private void InitializeSound()
        {
            // Create an instance of the SoundPlayer class.
            player = new SoundPlayer();

            // Listen for the LoadCompleted event.
            player.LoadCompleted += new AsyncCompletedEventHandler(player_LoadCompleted);

            // Listen for the SoundLocationChanged event.
            player.SoundLocationChanged += new EventHandler(player_LocationChanged);
        }
        private void button2_Click(object sender, EventArgs e)
        {

            ReportStatus("Playing .wav file synchronously.");
            player.PlaySync();
            ReportStatus("Finished playing .wav file synchronously.");




        }
        // Convenience method for setting message text in 
        // the status bar.
        private void ReportStatus(string statusMessage)
        {
            // If the caller passed in a message...
            if (!string.IsNullOrEmpty(statusMessage))
            {
                // ...post the caller's message to the status bar.
                this.statusBar.Text = statusMessage;
            }
        }
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            // Create a new OpenFileDialog.
            OpenFileDialog dlg = new OpenFileDialog();

            // Make sure the dialog checks for existence of the 
            // selected file.
            dlg.CheckFileExists = true;

            // Allow selection of .wav files only.
            dlg.Filter = "WAV files (*.wav)|*.wav";
            dlg.DefaultExt = ".wav";

            // Activate the file selection dialog.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file's path from the dialog.
                filepathTextbox.Text = dlg.FileName;


                // Assign the selected file's path to 
                // the SoundPlayer object.  
                player.SoundLocation = filepathTextbox.Text;
            }
        }

        // Enables and disables play controls.
        private void EnablePlaybackControls(bool enabled)
        {
            this.playOnceSyncButton.Enabled = enabled;
            this.playOnceAsyncButton.Enabled = enabled;
            this.playLoopAsyncButton.Enabled = enabled;
            this.stopButton.Enabled = enabled;
        }

        private void filepathTextbox_TextChanged(object sender, EventArgs e)
        {
            // Disable playback controls until the new .wav is loaded.
            EnablePlaybackControls(false);
        }

        private void loadSyncButton_Click(object sender, EventArgs e)
        {
            // Disable playback controls until the .wav is 
            // successfully loaded. The LoadCompleted event 
            // handler will enable them.
            EnablePlaybackControls(false);

            try
            {
                // Assign the selected file's path to 
                // the SoundPlayer object.  
                player.SoundLocation = filepathTextbox.Text;

                // Load the .wav file.
                player.Load();
            }
            catch (Exception ex)
            {
                ReportStatus(ex.Message);
            }
        }

        private void loadAsyncButton_Click(object sender, EventArgs e)
        {
            // Disable playback controls until the .wav is 
            // successfully loaded. The LoadCompleted event 
            // handler will enable them.
            EnablePlaybackControls(false);

            try
            {
                // Assign the selected file's path to 
                // the SoundPlayer object.  
                player.SoundLocation = this.filepathTextbox.Text;

                // Load the .wav file.
                player.LoadAsync();
            }
            catch (Exception ex)
            {
                ReportStatus(ex.Message);
            }
        }

        private void playOnceAsyncButton_Click(object sender, EventArgs e)
        {
            ReportStatus("Playing .wav file asynchronously.");
            player.Play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            ReportStatus("Stopped by user.");
        }

        // Handler for the LoadCompleted event.
        private void player_LoadCompleted(object sender,
            AsyncCompletedEventArgs e)
        {
            string message = String.Format("LoadCompleted: {0}",
                this.filepathTextbox.Text);
            ReportStatus(message);
            EnablePlaybackControls(true);
        }
        // Handler for the SoundLocationChanged event.
        private void player_LocationChanged(object sender, EventArgs e)
        {
            string message = String.Format("SoundLocationChanged: {0}",
                player.SoundLocation);
            ReportStatus(message);
        }

        private void playLoopAsyncButton_Click(object sender, EventArgs e)
        {
            ReportStatus("Looping .wav file asynchronously.");
            player.PlayLooping();
        }

        private void playOnceSyncButton_Click(object sender, EventArgs e)
        {
            ReportStatus("Playing .wav file synchronously.");
            player.PlaySync();
        }
    }
}
