@echo off
pushd %~dp0
call scripts\run-project.bat TaskBoard.Server\TaskBoard.Server.sln
popd
@echo on