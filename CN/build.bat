@echo off
chcp 65001
dotnet build --configuration Release Mist启动器.sln
@echo on
pause
