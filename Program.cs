using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AllegroAPI.Allegro;
using AllegroAPI.Data;
using AllegroAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, builder) =>
    {
        // Dodajemy konfigurację z appsettings.json
        var currentDirectory = Directory.GetCurrentDirectory();
        var jsonPath = Path.Combine(currentDirectory, "appsettings.json");
        builder.AddJsonFile(jsonPath, optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Odczytywanie ConnectionStrings z appsettings.json
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

        // Rejestracja AppDbContext z użyciem ConnectionString
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Rejestracja HttpClient
        services.AddHttpClient();

        // Odczytywanie Allegro ustawień z appsettings.json
        var accessToken = context.Configuration["Allegro:AccessToken"];
        var useSandbox = bool.Parse(context.Configuration["Allegro:UseSandbox"]);

        // Rejestracja AllegroClient z przekazaniem tokenu
        services.AddScoped<AllegroClient>(provider =>
        {
            var httpClient = provider.GetRequiredService<HttpClient>();
            return new AllegroClient(httpClient, accessToken, useSandbox);
        });


        // Dodajemy usługi do kontenera DI
        services.AddScoped<BillingService>();
        services.AddScoped<OfferCostService>();

    })
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

// Pobieramy BillingService z kontenera DI
var billingService = services.GetRequiredService<BillingService>();

// Uruchamiamy przetwarzanie wpisów billingowych
await billingService.ProcessBillingEntriesAsync();

host.Run();
