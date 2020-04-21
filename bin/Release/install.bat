@echo installing
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\installutil "%~dp0WeatherService.exe"
timeout 5
net start "CheckWeather Jorge"
timeout 10
@echo Done

