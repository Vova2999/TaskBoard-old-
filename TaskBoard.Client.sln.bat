@echo off
pushd %~dp0
call scripts\run-project.bat TaskBoard.Client\TaskBoard.Client.sln
popd
@echo on