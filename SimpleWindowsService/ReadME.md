dotnet publish --configuration Debug -o out 
dotnet publish --configuration Release -o out 

taskkill /PID 13388 /F

sc create SimpleWindowsService binPath= "C:\dev\SimpleBackgroundServiceArgs\SimpleWindowsService\out\SimpleWindowsService.exe --Parameter test434"

sc start SimpleWindowsService

sc stop SimpleWindowsService & sc delete SimpleWindowsService