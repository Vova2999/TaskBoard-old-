@echo off
pushd %~dp0
call scripts\take-settings.bat test-settings
popd
@echo on