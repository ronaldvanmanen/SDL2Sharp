@echo off

pushd "%~dp0"
set VSCMD_START_DIR=%CD%
call vsdevcmd.cmd 
editbin.exe %*
popd
