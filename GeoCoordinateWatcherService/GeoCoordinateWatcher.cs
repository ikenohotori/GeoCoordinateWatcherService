using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeoCoordinateWatcherService
{
    public partial class Service : ServiceBase
    {
        private static log4net.ILog _logger =
        log4net.LogManager.GetLogger(
        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private System.Threading.Timer _timer;
                
        public Service()
        {
            InitializeComponent();

            _timer = new System.Threading.Timer(
                Timer_Callback,
                null,
                Timeout.Infinite,
                Timeout.Infinite);
        }

        private void Timer_Callback(object state)
        {
            try
            {
                _logger.Info("実行中");
            }
            catch(Exception ex)
            {
                _logger.Error("エラーが発生しました", ex);
            }
        }

        protected override void OnStart(string[] args)
        {
            _logger.Info("スタートしました");
            _timer.Change(0, 1000);
        }

        protected override void OnStop()
        {
            _logger.Info("ストップしました");
        }

        internal void DubugRun()
        {
            OnStart(null);
            Console.ReadLine();
            OnStop();
        }
    }
}
