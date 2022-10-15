d# Getting database ready for this demo

This demo relies on a database which is set up in SQLEXPRESS (Sql Server).



## Seeded mountain database

Tallest mountains in Norwegian municipialities - data from Kartverket.
The project MountainDataSet.Console contains a simple tool to create a 
json file from a available excel file from Kartverket for all the tallest 
mountains in the municipialites in Norway. 


Ran these commands:

``` bash
dotnet tool install --global dotnet-ef

dotnet tool update --global dotnet-ef

dotnet ef migrations add InitialCreate
```

You might have to update the dotnet-ef tools (when I ran the command I had to update it, it updated
to version 6.0.10). 


### Update database to latest migration for this demo 

First build the solution and then switch the folder Data inside this repo inside
View->Other windows->Package Manager Console in Visual Studio.

Then run this command: 

``` bash
dotnet ef database update 
```
<hr />

Last update 15.10.2022. 
