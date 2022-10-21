using AspNet_GraphQLDemoV2.Common.Types.Models;
using AspNet_GraphQLDemoV2.Data;
using AspNet_GraphQLDemoV2.Server.GraphQL.Types.Mutations;
using AspNet_GraphQLDemoV2.Server.GraphQL.Types.Queries;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MountainsV2Db");
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

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

app.Run();
