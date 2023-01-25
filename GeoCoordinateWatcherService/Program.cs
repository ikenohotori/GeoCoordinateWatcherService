using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace GeoCoordinateWatcherService
{
    static class Program
    {
        private static log4net.ILog _logger =
log4net.LogManager.GetLogger(
System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main()
        {
            if(Environment.UserInteractive)
            {
                _logger.Info("デバッグモードで実行されました");
                var service = new Service();
                service.DubugRun();
            }
            else
            {
                _logger.Info("サービスモードで実行されました");
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service()
                };
                ServiceBase.Run(ServicesToRun);

            }
        }
    }
}
