﻿using System;
using System.Media;

namespace Minesweeper
{
    public class Musik
    {
        private SoundPlayer soundPlayer = new SoundPlayer();

        public Musik(string path)
        {
            try
            {
                soundPlayer.SoundLocation = path;
                soundPlayer.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading sound: {ex.Message}");
            }
        }

        public void MusikPlay()
        {
            try
            {
                soundPlayer.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error playing sound: {e.Message}");
            }
        }
        public void MusikPlayLooping()
        {
            try { 
                soundPlayer.PlayLooping();
            }
            catch (Exception e) { }
        }

        public void MusikStop()
        {
            try
            {
                soundPlayer.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error stopping sound: {ex.Message}");
            }
        }
    }
}
