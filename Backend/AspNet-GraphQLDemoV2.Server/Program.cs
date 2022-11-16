using AspNet_GraphQLDemoV2.Common.Types.Models;
using AspNet_GraphQLDemoV2.Data;
using AspNet_GraphQLDemoV2.Server.GraphQL.Types.Mutations;
using AspNet_GraphQLDemoV2.Server.GraphQL.Types.Queries;
using AspNetGraphQLDemoV2.Server.GraphQL.Types.Subscriptions;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MountainsV2Db");
builder.Services
    .AddDbContext<MountainDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    })
    .AddCors()
    .AddGraphQLServer()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .RegisterDbContext<MountainDbContext>()
    .AddQueryType<MountainQueries>()
    .AddMutationType<MountainMutations>()
    .AddSubscriptionType<MountainSubscriptions>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); //this is just a demo.. allow CORS from whatever

app.UseHttpsRedirection();
app.UseWebSockets();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
