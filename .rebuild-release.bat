@echo off
pushd %~dp0
call scripts\build\rebuild-all-solutions.bat Release
popd
@echo on