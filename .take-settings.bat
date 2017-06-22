echo off

set settingsDirectory=settings

rmdir /S /Q %settingsDirectory%
mkdir %settingsDirectory%

cd %settingsDirectory%

echo ^<?xml version="1.0" encoding="utf-8"?^> > TaskBoard.Client.UI.Configuration.xml
echo ^<ClientUiConfiguration^> >> TaskBoard.Client.UI.Configuration.xml
echo 	^<ServerAddress^>http://127.0.0.1:82/^</ServerAddress^> >> TaskBoard.Client.UI.Configuration.xml
echo 	^<TimeoutMs^>5000^</TimeoutMs^> >> TaskBoard.Client.UI.Configuration.xml
echo 	^<Login^>login^</Login^> >> TaskBoard.Client.UI.Configuration.xml
echo 	^<Password^>password^</Password^> >> TaskBoard.Client.UI.Configuration.xml
echo 	^<SaveLoginAndPassword^>true^</SaveLoginAndPassword^> >> TaskBoard.Client.UI.Configuration.xml
<nul set /p strTemp=^</ClientUiConfiguration^> >> TaskBoard.Client.UI.Configuration.xml

echo ^<?xml version="1.0" encoding="utf-8"?^> > TaskBoard.Server.UI.Configuration.xml
echo ^<ServerUiConfiguration^> >> TaskBoard.Server.UI.Configuration.xml
echo 	^<UserLogin^>login^</UserLogin^> >> TaskBoard.Server.UI.Configuration.xml
echo 	^<UserPassword^>password^</UserPassword^> >> TaskBoard.Server.UI.Configuration.xml
echo 	^<SaveLoginAndPassword^>true^</SaveLoginAndPassword^> >> TaskBoard.Server.UI.Configuration.xml
<nul set /p strTemp=^</ServerUiConfiguration^> >> TaskBoard.Server.UI.Configuration.xml

echo ^<?xml version="1.0" encoding="utf-8"?^> > TaskBoard.Server.Configuration.xml
echo ^<ServerConfiguration^> >> TaskBoard.Server.Configuration.xml
echo 	^<ServerAddress^>http://127.0.0.1:82/^</ServerAddress^> >> TaskBoard.Server.Configuration.xml
<nul set /p strTemp=^</ServerConfiguration^> >> TaskBoard.Server.Configuration.xml

cd ..

echo on