using F1Pontszamitos_S6.Shared.Utils;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(x => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});




await builder.Build().RunAsync();

//msedge --remote-debugging-port=9222 --user-data-dir="C:\Users\Dani\AppData\Local\Temp\blazor-edge-debug" --no-first-run https://localhost:7207/ --> debugger tab