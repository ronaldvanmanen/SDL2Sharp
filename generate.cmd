@ECHO OFF
pwsh.exe -NoLogo -NoProfile -ExecutionPolicy ByPass -Command "& """%~dp0scripts\build.ps1""" -generate %*"
EXIT /B %ERRORLEVEL%
