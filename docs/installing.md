#Installing/Unistalling the service

##Installer
Inside the bin/Release [Installer](./bin/Release/install.bat) to be used to install the service
- Execute from cmd as Administrator
- Must have .NET Framework 4.0.3 or above installed (Preferably in PATH)

### Actions Executed by the bat files
- Run installutil NET framework tool.
- Start the service after install

##Unistalling
Inside the bin/Release [Uninstaller](./bin/Release/uninstall.bat) to be used for uninstalling
- Execute from cmd as Administrator
- Must have .NET Framework 4.0.3 or above installed (Preferably in PATH)

### Actions Exceuted by the bat file
- Stop the service
- Run installutil NET framework tool.
