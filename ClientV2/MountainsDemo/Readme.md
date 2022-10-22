### GraphQL demo client

Followed the Strawberry shake client intro here:

https://chillicream.com/docs/strawberryshake/get-started

Start the server in this solution (start without debugging)

Inside the folder ClientV2\MountainsDemo run commands :

```
dotnet tool restore

dotnet graphql init https://localhost:7074/graphql/   
```


Fetch a mountain (query):

```csharp
query HentMountain {
  mountain (id: 1){
    id
    officialName
    metresAboveSeaLevel
    primaryFactor
    referencePoint
    county
    comments
    municipality
  }
}
```