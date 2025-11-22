## COP4870, Fall 2025, Semester Project
Donovan Stonebreaker  
Professor: Christopher Mills  

C# v8.0, using Avalonia GUI Framework
****
### Requirements / Dependencies:
The built in api view / launcher uses the Avalonia UI WebView component. If you are using the complete executable then you will need to ensure the following.

Windows: 
    There is a small chance it may not run on a windows machine properly, I had no issues with blocking when I was running through Ubuntu but the api was throwing a fit on windows so I had to do some last minute shifting around. I know that it runs for a fact with Ubuntu 24.04.3 LTS so you _might_ need to run on there if windows doesn't work. I am away from home and don't have access to a windows machine and my vm decided to update and break itself just in time for testing it.
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
