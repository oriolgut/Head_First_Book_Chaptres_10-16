﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.ViewModel
{
    using Model;
    using System.ComponentModel;
    using Windows.UI.Xaml;

    class StopwatchViewModel : INotifyPropertyChanged
    {
        private StopwatchModel _stopwatchModel = new StopwatchModel();
        private DispatcherTimer _timer = new DispatcherTimer();

        private int _lastHours;
        private int _lastMinutes;
        private decimal _lastSeconds;
        private bool _lastRunning;

        private int _lastLapHours;
        private int _lastLapMinutes;
        private decimal _lastLapSeconds;

        public StopwatchViewModel()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += TimerTick;
            _timer.Start();
            Start();

            _stopwatchModel.LapTimeUpdated += LapTimeUpdatedEventHandler;
        }

        public bool Running
        {
            get
            {
                return _stopwatchModel.Running;
            }
        }

        public int Hours
        {
            get
            {
                return _stopwatchModel.Elapsed.HasValue ? _stopwatchModel.Elapsed.Value.Hours : 0;
            }
        }

        public int Minutes
        {
            get
            {
                return _stopwatchModel.Elapsed.HasValue ? _stopwatchModel.Elapsed.Value.Minutes : 0;
            }
        }

        public decimal Seconds
        {
            get
            {
                if (_stopwatchModel.Elapsed.HasValue)
                {
                    return _stopwatchModel.Elapsed.Value.Seconds + (_stopwatchModel.Elapsed.Value.Milliseconds * .001M);
                }
                else
                {
                    return 0.0M;
                }   
            }
        }

        public int LapHours
        {
            get
            {
                return _stopwatchModel.LapTime.HasValue ? _stopwatchModel.LapTime.Value.Hours : 0;
            }
        }

        public int LapMinutes
        {
            get
            {
                return _stopwatchModel.LapTime.HasValue ? _stopwatchModel.LapTime.Value.Minutes : 0;
            }
        }

        public decimal LapSeconds
        {
            get
            {
                if (_stopwatchModel.LapTime.HasValue)
                {
                    return _stopwatchModel.LapTime.Value.Seconds + (_stopwatchModel.LapTime.Value.Milliseconds * .001M);
                }
                else
                {
                    return 0.0M;
                }
            }
        }

        public void Start()
        {
            _stopwatchModel.Start();
        }

        public void Stop()
        {
            _stopwatchModel.Stop();
        }

        public void Lap()
        {
            _stopwatchModel.Lap();
        }

        public void Reset()
        {
            bool running = Running;
            _stopwatchModel.Reset();
            if (running)
            {
                _stopwatchModel.Start();
            }
            OnPropertyChanged(nameof(LapHours));
            OnPropertyChanged(nameof(LapMinutes));
            OnPropertyChanged(nameof(LapSeconds));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TimerTick(object sender, object e)
        {
            if (_lastRunning != Running)
            {
                _lastRunning = Running;
                OnPropertyChanged(nameof(Running));
            }

            if (_lastHours != Hours)
            {
                _lastHours = Hours;
                OnPropertyChanged(nameof(Hours));
            }

            if (_lastMinutes != Minutes)
            {
                _lastMinutes = Minutes;
                OnPropertyChanged(nameof(Minutes));
            }

            if (_lastSeconds != Seconds)
            {
                _lastSeconds = Seconds;
                OnPropertyChanged(nameof(Seconds));
            }
        }

        private void LapTimeUpdatedEventHandler(object sender, LapEventArgs e)
        {
            if (_lastLapHours != LapHours)
            {
                _lastLapHours = LapHours;
                OnPropertyChanged(nameof(LapHours));
            }

            if (_lastLapMinutes != LapMinutes)
            {
                _lastLapMinutes = LapMinutes;
                OnPropertyChanged(nameof(LapMinutes));
            }

            if (_lastLapSeconds != LapSeconds)
            {
                _lastLapSeconds = LapSeconds;
                OnPropertyChanged(nameof(LapSeconds));
            }
        }
    }
}
