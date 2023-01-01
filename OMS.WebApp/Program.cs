using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OMS.Plugins.EFCoreSqlServer;
using OMS.Plugins.InMemory;
using OMS.UseCases.Kontorhuse;
using OMS.UseCases.Kontorhuse.Interfaces;
using OMS.UseCases.Lejere;
using OMS.UseCases.Lejere.Interfaces;
using OMS.UseCases.Medarbejdere;
using OMS.UseCases.Medarbejdere.Interfaces;
using OMS.UseCases.PluginInterfaces;
using OMS.WebApp.Data;
using OMS.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

var connstr = builder.Configuration.GetConnectionString("OfficeManagement");

// Configure EF Core for Identity
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(connstr);
});

// Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    // Sættes til false for ikke at skulle bekræfte email - skal ændres ved deployment
    options.SignIn.RequireConfirmedEmail = false;

}).AddEntityFrameworkStores<AccountDbContext>();


// Bemærk Factory pga. Blazor Server
builder.Services.AddDbContextFactory<OMSContext>(options =>
{
    options.UseSqlServer(connstr);
});

//builder.Services.AddDbContext<OMSContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("OfficeManagement"));
//});


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Dependency Injection laves her
// ILejerRepository implementeres her med LejerRepository og vil instatiere et objekt af LejerRepository klassen
// og give det til konstruktøren af use casen i 'this.lejerRepository'
// og give det videre til 'lejerRepository' feltet (private readonly)
// Mapping mellem interface og implementering af servicen

// Datastore og database (LejerRepository fx) kan der kun være en af, derfor singleton når inmemory bruges.
// Ellers får man dataintegritetsproblemer.
// I database er det allerede singleton, og derfor kan der her være transient.

if (builder.Environment.IsEnvironment("TESTING"))
{
    // For at css isolation virker, skal denne linje køres. Måske unødvendig i .net 7
    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

    builder.Services.AddSingleton<ILejerRepository, LejerRepository>();
    builder.Services.AddSingleton<IMedarbejderRepository, MedarbejderRepository>();
    builder.Services.AddSingleton<IKontorhusRepository, KontorhusRepository>();
}

builder.Services.AddTransient<ILejerRepository, LejerEFCoreRepository>();
builder.Services.AddTransient<IMedarbejderRepository, MedarbejderEFCoreRepository>();
builder.Services.AddTransient<IKontorhusRepository, KontorhusEFCoreRepository>();

builder.Services.AddTransient<IViewLejereByNameUseCase, ViewLejereByNameUseCase>();
builder.Services.AddTransient<IAddLejerUseCase, AddLejerUseCase>();
builder.Services.AddTransient<IEditLejerUseCase, EditLejerUseCase>();
builder.Services.AddTransient<IViewLejerByIdUseCase, ViewLejerByIdUseCase>();

builder.Services.AddTransient<IViewMedarbejderByNameUseCase, ViewMedarbejderByNameUseCase>();
builder.Services.AddTransient<IAddMedarbejderUseCase, AddMedarbejderUseCase>();

builder.Services.AddTransient<IViewKontorhusByNameUseCase, ViewKontorhusByNameUseCase>();
builder.Services.AddTransient<IAddKontorhusUseCase, AddKontorhusUseCase>();
builder.Services.AddTransient<IViewKontorhusByIdUseCase, ViewKontorhusByIdUseCase>();
builder.Services.AddTransient<IEditKontorhusUseCase, EditKontorhusUseCase>();

//Add additional Service for Hide/Show Navbar
builder.Services.AddSingleton<ViewOptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
