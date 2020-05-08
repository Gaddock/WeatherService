using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;



namespace WeatherService
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }


    public class RootObjectWeatherResponse
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }


    class GetWeatherDataAndWriteToFile
    {
        private const string URL = "http://api.openweathermap.org/data/2.5/weather";


        public static string GetdataAndWrite()
        {
            HttpClient client = new HttpClient();
            string temppath = Path.GetTempPath();
            string toFile;

            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            

            HttpResponseMessage response = client.GetAsync("?lat=32.780061&lon=-96.798265&appid=<InsertAppIdHere>&units=metric").Result;


            if (response.IsSuccessStatusCode)
            {
                var serviceResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var parsedjson = JsonSerializer.Deserialize<RootObjectWeatherResponse>(serviceResponse);
                //TODO Find a case where list is higher than 1 element
                if (parsedjson.weather[0].main == "Rain")
                {
                    File.AppendAllText(temppath + "\\JorgeWeatherLog.csv", parsedjson.main.temp + "C,True,");
                }
                else
                {
                    File.AppendAllText(temppath + "\\JorgeWeatherLog.csv",parsedjson.main.temp + "C,False,");
                }
                toFile = temppath + "\\JorgeWeatherLog.csv";
            }

            else
            {
                File.AppendAllText(temppath + "\\JorgeWeatherLogError.csv", "Error connecting to the service, please make sure you are connected to the Internet. Status: " + response.StatusCode.ToString()+"," + Environment.NewLine);
                toFile = temppath + "\\JorgeWeatherLogError.csv";
            }

            return toFile;
        }
    }
}
