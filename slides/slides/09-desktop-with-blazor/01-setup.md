### Setup

1. Install `ElectronNET.API`
1. Update 2 files (Program.cs and Startup.cs)
1. Use `ElectronNET.CLI` to run "init" task

```sh
dotnet add package ElectronNET.API
dotnet new tool-manifest
dotnet tool install ElectronNET.CLI
dotnet electronize init
```

Note: