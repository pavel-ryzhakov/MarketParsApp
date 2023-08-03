using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketParsApp.Parser
{
    internal class DownloadTimer
    {
        
        private Stopwatch stopwatch { get; }
        public TimeSpan Elapsed { get; }


        public void Start()
        {
            stopwatch.Start();
        }

        public string Stop()
        {
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = "Время выполнения : "+ String.Format("{0:00}:{1:00}.{2:00}",
                 ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return elapsedTime;
        }

        

    }
}
