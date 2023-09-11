using System;
using System.Media;
using System.Windows.Media;


namespace Minesweeper
    {
        public class Musik
        {
            private MediaPlayer mediaPlayer = new MediaPlayer();

            public Musik(string path)
            {
                try
                {
                    mediaPlayer.Open(new Uri(path));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error loading sound: {e.Message}");
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
                    Console.WriteLine($"Error playing sound: {e.Message}");
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
                    Console.WriteLine($"Error playing sound: {e.Message}");
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
                    Console.WriteLine($"Error stopping sound: {e.Message}");
                }
            }
            public void SetVolume(int volume)
            {
                mediaPlayer.Volume = volume / 100.0f;
            }
    }
   
}
