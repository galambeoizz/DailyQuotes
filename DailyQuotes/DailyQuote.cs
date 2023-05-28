using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DailyQuotes
{
    public partial class DailyQuote : ServiceBase
    {
        private Timer timer = null;
        public DailyQuote()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Tạo 1 timer từ libary System.Timers
            timer = new Timer();
            // Execute mỗi 60s
            timer.Interval = 60000;
            // Những gì xảy ra khi timer đó dc tick
            timer.Elapsed += timer_Tick;
            // Enable timer
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, ElapsedEventArgs args)
        {
            // Xử lý một vài logic ở đây
            try
            {
                Utilities.CompareDate();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override void OnStop()
        {
            timer.Enabled = true;
        }
    }
}
