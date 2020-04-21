# WeatherService
## Weather Service on C#
Simple Windows Service that connects to openweather API, gets the temperature ands logs it to %TEMP%

###Important Notes
1. As the service is being run by system user %TEMP% is relative to that user.
2. The Service creates a logs to Event Viewer: NewWeatherLog
