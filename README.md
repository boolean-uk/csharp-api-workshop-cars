# C# API Workshop for Request & Responses

This 

## Consider
- Endpoints
- Repository
- Data Layer

# C# Entity Framework Introduction Workshop

## created project with these commands

mkdir csharp-entity-framework-intro-workshop  

dotnet new sln --name workshop  

dotnet new nunit --name workshop.tests  

dotnet new webapi --name workshop.wwwapi  


## Important!

-ensure that you have run the 'dotnet new gitignore' command in the root of the folder (where the .sln resides)  
-ensure that you have added the following to the gitignore:  
```

*/**/bin/Debug   
*/**/bin/Release   
*/**/obj/Debug   
*/**/obj/Release   
```
What the above does is prevent those folders from being uploaded to git.  These folders may well contain build/credential information so we should'nt upload this.

-ensure both 'appsettings.json' & 'appsettings.Development.json' are 'Ignore and untracked.'  This will add the following two lines to the gitignore:
```
/workshop.wwwapi/appsettings.json
/workshop.wwwapi/appsettings.Development.json
```


## Entity Framework Dependencies   

Install these using the nuget package manager.  Ensure you have the api set as the default project!  

```
install-packages microsoft.entityframeworkcore.design  

install-packages microsoft.entityframeworkcore.design  

install-packages microsoft.entityframeworkcore.design  

install-packages microsoft.entityframeworkcore.design  

install-packages npgsql.entityframeworkcore.postgresql  
```

## 
