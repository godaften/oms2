using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Dependency Injection laves her
// ILejerRepository implementeres her med LejerRepository og vil instatiere et objekt af LejerRepository klassen
// og give det til konstruktøren af use casen i 'this.lejerRepository'
// og give det videre til 'lejerRepository' feltet (private readonly)
// Mapping mellem interface og implementering af servicen

// Datastore og database (LejerRepository fx) kan der kun være en af, derfor singleton
// Ellers får man dataintegritetsproblemer
builder.Services.AddSingleton<ILejerRepository, LejerRepository>();
builder.Services.AddSingleton<IMedarbejderRepository, MedarbejderRepository>();
builder.Services.AddSingleton<IKontorhusRepository, KontorhusRepository>();

// Transient ved use cases - ikke ved database
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

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
