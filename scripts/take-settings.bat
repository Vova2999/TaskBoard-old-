pushd %~dp0

rmdir /S /Q ..\settings
md ..\settings
xcopy ..\configs\%1 ..\settings

popd