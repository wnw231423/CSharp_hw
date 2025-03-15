using System;

namespace assignment4
{
    internal class Clock
    {
        private int Interval { get; set; }

        // 事件
        public event EventHandler? Tick;
        public event EventHandler? Alarm;

        public Clock(int interval) 
        {
            this.Interval = interval;
        }

        protected virtual void OnTick() 
        {
            Tick?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnAlarm() 
        {
            Alarm?.Invoke(this, EventArgs.Empty);
        }

        public void start() 
        {
            Console.WriteLine($"闹钟开始运行，{this.Interval}秒后响铃");
            for (int i = 0; i < Interval; i++)
            {
                OnTick();
                if (i == Interval - 1) {
                    OnAlarm();
                }
                Thread.Sleep(1000);  // 模拟一秒
            }
        }
    }
}
