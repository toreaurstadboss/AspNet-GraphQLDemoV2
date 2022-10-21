
## GraphQL query samples 

### Sorting 
HotChocolate can support *sorting*. 

First set up in Program.cs with the AddSorting to enable sorting feature of HotChocolate/GraphQL. 

```
builder.Services
    .AddDbContext<MountainDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    })
    .AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .RegisterDbContext<MountainDbContext>()
    .AddQueryType<MountainQueries>()
    .AddMutationType<MountainMutations>();

```

Next, Add UseSorting attribute to method that should support sorting 

```csharp
        [UseSorting]
        public async Task<List<Mountain>> GetMountains([Service] MountainDbContext mountainDb)
        {
            return await mountainDb.Mountains.ToListAsync();
        }
```

Now, we can make a query against HotChocolate using for example the following sample query in Banana Cake Pop:

```
query {
  mountains(order: [{primaryFactor: DESC}])  {
    id
    officialName
    metresAboveSeaLevel
    primaryFactor
  }
}
```

We get a list of the most prominent mountains in Norway with highest primary factor. 

