@ECHO OFF
powershell.exe -NoLogo -NoProfile -ExecutionPolicy ByPass -Command "& """%~dp0build-sdl2ttf.ps1""" %*"
EXIT /B %ERRORLEVEL%
