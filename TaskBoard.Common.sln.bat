@echo off
pushd %~dp0
call scripts\run-project.bat TaskBoard.Common\TaskBoard.Common.sln
popd
@echo on