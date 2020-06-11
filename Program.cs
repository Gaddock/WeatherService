using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        
#if DEBUG
            CheckWeather myService = new CheckWeather();
            myService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new CheckWeather()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
