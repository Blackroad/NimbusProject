@echo off
rem --- Start Platform Service if it isn't already running
set rootDir=%cd%
cd .\Computing\Platform\NimbusPlatformService\bin\Release
tasklist | find "NimbusPlatformService"
if %ERRORLEVEL% EQU 1 start NimbusPlatformService.exe
cd %rootDir%
rem --- Start UI
cd .\Computing\Application\NimbusApp\bin\Release && start NimbusApp.exe
rem cd .\Computing\Application\NimbusApp\bin\Debug && start NimbusApp.exe
cd %rootDir%
rem --- Start Virtual Console. 3 types of catheter
rem timeout 2
cd .\Tools\VirtualConsoleApp\bin\Release && start VirtualConsoleApp.exe BalloonCatheterPersonality.cs
