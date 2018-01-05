pushd %~dp0

tasklist | find "MSBuild.exe" > nul
if %errorLevel%==0 taskkill /IM MSBuild.exe /f

call build-solution.bat ..\..\_source\TaskBoard.Common\TaskBoard.Common.sln %1
call build-solution.bat ..\..\_source\TaskBoard.Server\TaskBoard.Server.sln %1
call build-solution.bat ..\..\_source\TaskBoard.Client\TaskBoard.Client.sln %1

tasklist | find "MSBuild.exe" > nul
if %errorLevel%==0 taskkill /IM MSBuild.exe /f

if %1==Release del /S /Q ..\Build\*.pdb > nul

popd