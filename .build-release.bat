@echo off
pushd %~dp0
call scripts\build\build-all-solutions.bat Release
popd
@echo on