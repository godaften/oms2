using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OMS.Plugins.InMemory;
using OMS.UseCases.Lejere;
using OMS.UseCases.Lejere.Interfaces;
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
// og give det til konstruktøren af use casen i 'this.lejerRepository' og give det videre til 'lejerRepository' feltet (private readonly)
builder.Services.AddSingleton<ILejerRepository, LejerRepository>();
// Transient ved use cases - ikke ved database
builder.Services.AddTransient<IViewLejereByNameUseCase, ViewLejereByNameUseCase>();
builder.Services.AddTransient<IAddLejerUseCase, AddLejerUseCase>();
builder.Services.AddTransient<IEditLejerUseCase, EditLejerUseCase>();

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
