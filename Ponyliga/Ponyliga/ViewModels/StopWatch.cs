using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace Ponyliga.ViewModels
{
    public class StopWatch : INotifyPropertyChanged
    {
        Stopwatch stopWatch = new Stopwatch();

        private String time;
        public String Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        // Event handler for binding the time
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void StartStopWatch()
        {
            stopWatch.Start();

            // starts a timer using the device clock
            Device.StartTimer(TimeSpan.FromMilliseconds(0), () =>
            {
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                

                
                Time = elapsedTime.ToString();

                //Hours = stopWatch.Elapsed.Hours.ToString();
                //Minutes = stopWatch.Elapsed.Minutes.ToString();
                //Seconds = stopWatch.Elapsed.Seconds.ToString();
                //Milliseconds = stopWatch.Elapsed.Milliseconds.ToString();

                return true;
            });
        }

        public void StopStopWatch()
        {
            stopWatch.Stop();
        }

        public void ResetStopWatch()
        {
            stopWatch.Reset();
        }

        public void ContinueStopWatch()
        {
            StartStopWatch();
        }

        public TimeSpan AddTime(TimeSpan StoppedTime, TimeSpan Strafzeit)
        {
            TimeSpan Lasttime = StoppedTime + Strafzeit;
            return Lasttime;
        }
    }
}
