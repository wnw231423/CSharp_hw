using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    internal class Subscriber
    {
        private static void OnTickHandler(object? sender, EventArgs e) 
        {
            Console.WriteLine("Tick...");
        }

        private static void OnAlarmHandler(object? sender, EventArgs e)
        {
            Console.WriteLine("ALARM!!!!!");
        }

        public static void subcribe(Clock clock)
        {
            clock.Tick += OnTickHandler;
            clock.Alarm += OnAlarmHandler;
        }
    }
}
