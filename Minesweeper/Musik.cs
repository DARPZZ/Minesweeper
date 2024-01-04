using System;
using System.Diagnostics;
using System.Media;
using System.Windows.Media;


namespace Minesweeper
    {
        public class Musik
        {
            private MediaPlayer mediaPlayer = new MediaPlayer();

        public Musik(string relativePath)
        {
            try
            {
                string projectPath = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string fullPath = System.IO.Path.Combine(projectPath, relativePath);
                Debug.WriteLine($"Loading sound from: {fullPath}");
                mediaPlayer.Open(new Uri(fullPath));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error loading sound: {e.Message}");
            }
        }



        public void MusikPlay()
            {
                try
                {
                    mediaPlayer.Play();
                }
                catch (Exception e)
                {
                Debug.WriteLine($"Error playing sound: {e.Message}");
                }
            }

            public void MusikPlayLooping()
            {
                try
                {
                    mediaPlayer.MediaEnded += (sender, e) => mediaPlayer.Position = TimeSpan.Zero;
                    mediaPlayer.Play();
                }
                catch (Exception e)
                {
                Debug.WriteLine($"Error playing sound: {e.Message}");
                }
            }

            public void MusikStop()
            {
                try
                {
                    mediaPlayer.Stop();
                }
                catch (Exception e)
                {
                Debug.WriteLine($"Error stopping sound: {e.Message}");
                }
            }
            public void SetVolume(int volume)
            {
                mediaPlayer.Volume = volume / 100.0f;
            }
    }
   
}
