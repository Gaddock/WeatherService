
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace WeatherService
{
    public partial class CheckWeather : ServiceBase
    {
        private int eventID = 1;//Incrementing Event ID
        public CheckWeather()
        {
            InitializeComponent();
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("JorgeApp"))
            {
                EventLog.CreateEventSource("jorgeApp", "NewWeatherLog");
            }
            eventLog1.Source = "JorgeApp";
            eventLog1.Log = "NewWeatherLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("OnStart Step Log, Weather Checking App");
            Timer timer = new Timer();
            timer.Interval = 60000 * 5; // Every 5 minutes
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            string logFile;
            logFile = GetWeatherDataAndWriteToFile.GetdataAndWrite();
            eventLog1.WriteEntry("Polling the System, weather data written to: " + logFile, EventLogEntryType.Information, eventID++);
        }
        protected override void OnStop()
        {
            eventLog1.WriteEntry("OnStop Step Log, Weather Checking App");
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }

    }
}
