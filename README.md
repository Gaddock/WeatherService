# WeatherService
## Weather Service on C#
Simple Windows Service that connects to openweather API, gets the temperature ands logs it to %TEMP%

### Important Notes
1. As the service is being run by system user %TEMP% is relative to that user.
2. The Service creates a logs to Event Viewer: NewWeatherLog
3. You must add the API key to connect to the service.

### Future releases
1. Add a simple way of creating a config file to read the API key
