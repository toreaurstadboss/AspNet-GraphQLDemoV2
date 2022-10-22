### GraphQL demo client

Followed the Strawberry shake client intro here:

https://chillicream.com/docs/strawberryshake/get-started



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