@echo uninstalling
net STOP "CheckWeather Jorge"
timeout 10
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\installutil /u "%~dp0WeatherService.exe"
timeout 5s
@echo Done