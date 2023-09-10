using System;
using System.Diagnostics;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Mineryder
{
    public class Timer
    {
        DispatcherTimer dispatcherTimer;
        private int h, m, s;
        public event Action<string> TimeChanged;

        public Timer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += OnTimerTick;
        }

        public void Start()
        {

            dispatcherTimer.Start();
        }

        public void Stop()
        {

            dispatcherTimer.Stop();
        }
        public void reset()
        {
            s = 0;
            m = 0;
            h = 0;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            s++;
            if (s >= 60)
            {
                s = 0;
                m++;
                if (m >= 60)
                {
                    m = 0;
                    h++;
                }
            }
            
            TimeChanged?.Invoke($"{h:D2}:{m:D2}:{s:D2}");

        }
    }
}
