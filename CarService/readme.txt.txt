1. ensure that you have installed putty together with pscp.
2. ensure that raspberry pi is running and connected to your network.
2. write connection details to raspberry pi in build.cake file:
destinationIp, destinationDirectory, username, sessionname, executableName
3. deploy the application to raspberry by running ./build in powershell.