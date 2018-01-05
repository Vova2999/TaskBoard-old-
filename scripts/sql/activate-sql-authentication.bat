for /f "usebackq tokens=1,2,*" %%i in (`reg query "HKLM\SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL" /v "SQLEXPRESS"`) do set "SqlServerName=%%~k"
for /f "usebackq tokens=1,2,*" %%i in (`reg query "HKLM\SOFTWARE\Microsoft\Microsoft SQL Server\%SqlServerName%\MSSQLServer" /v "LoginMode"`) do set "LoginMode=%%~k"
if %LoginMode% equ 2 exit
reg add "HKLM\SOFTWARE\Microsoft\Microsoft SQL Server\%SqlServerName%\MSSQLServer" /v "LoginMode" /t REG_DWORD /d 2 /f
net stop MSSQL$SQLEXPRESS
net start MSSQL$SQLEXPRESS