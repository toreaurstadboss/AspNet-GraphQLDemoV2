using AspNetGraphQLDemoV2.Client;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorise(options =>
  {
      options.Immediate = true;
  })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
builder.Services.AddGraphQLDemoClient().ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7074/graphql"));
await builder.Build().RunAsync();
