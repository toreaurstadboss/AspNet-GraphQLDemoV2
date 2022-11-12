### GraphQL demo client

Followed the Strawberry shake client intro here:

https://chillicream.com/docs/strawberryshake/get-started

Start the GraphQL Hot Chocolate server in this solution (start without debugging) to make sure it is running and available for metadata download
of your API. It is set up to run at port 7074.

Inside the folder ClientV2\MountainsDemo run commands :

```
dotnet tool restore

dotnet graphql init https://localhost:7074/graphql/   
```

**Note** - when adding queries, mutations, mutations or subscriptions - run the command : 

```
dotnet graphql init https://localhost:7074/graphql
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


Update a mountain (mutation): 


```

 mutation UpdateMountain {
  updateMountain(mountain: {
    id: 1,
    primaryFactor: 123,
    metresAboveSeaLevel: 123,
    county: "En test",
    municipality: "En test kommune",
    officialName: "En test navn",
    comments: "en oppdatering"
  }) {
    id
    comments
    primaryFactor
    officialName
    municipality
    comments
    metresAboveSeaLevel
    county  
  }

}
```