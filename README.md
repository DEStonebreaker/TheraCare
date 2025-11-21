## COP4870, Fall 2025, Semester Project
Donovan Stonebreaker  
Professor: Christopher Mills  

C# v8.0, using Avalonia GUI Framework
****
### Requirements / Dependencies:
The built in api view / launcher uses the Avalonia UI WebView component. If you are using the complete executable then you will need to ensure the following.

Windows: 
****
#### To Use: 
Start the backend
```
~$ cd ./Api.TheraCare/
~$ dotnet build; dotnet run --launch-profile https;
    # Will need to navigate to /swagger after opening.
```

To start the frontend, you can use the given executable file or in a new terminal tab, build and launch.
```
~$ cd ./Avalonia.TheraCare/
~$ dotnet build; dotnet run;
```
