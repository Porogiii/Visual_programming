using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport.Models.ViewModels
{
    public class Clock : INotifyPropertyChanged
    {
        private DispatcherTimer _disTimer = new DispatcherTimer();

        public event PropertyChangedEventHandler? PropertyChanged;
        public EventHandler<DateTime> OnEveryHour = (s, e) => { };

        public string CurrentTime { get; set; } = "Current Time";
        public string NextDownloadCycle { get; set; } = "Downloading in: ";

        private DateTime _nextCycle = DateTime.Now.AddHours(3);

        public Clock()
        {
            _disTimer.Interval = TimeSpan.FromSeconds(1);
            _disTimer.Tick += DispatcherTimer_Tick;
            _disTimer.Start();
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            var now = DateTime.Now;
            if (now >= _nextCycle)
            {
                _nextCycle = DateTime.Now.AddHours(3);
                OnEveryHour(this, now);
            }
            TimeSpan ts = _nextCycle - now;
            NextDownloadCycle = String.Format(
                "Next request at {0}(in {1}m{2}s)",
                _nextCycle.ToString("HH:mm:ss"),
                Math.Round(ts.TotalMinutes) - 1,
                ts.Seconds
            );
            CurrentTime = now.ToString("HH:mm:ss");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTime)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NextDownloadCycle)));
        }
    }
}
