@ECHO OFF
powershell.exe -NoLogo -NoProfile -ExecutionPolicy ByPass -Command "& """%~dp0nugetize-sdl2.ps1""" %*"
EXIT /B %ERRORLEVEL%
