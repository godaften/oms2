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

var builder = WebApplication.CreateBuilder(args);

// Configure Auth
builder.Services.AddAuthorization(options =>
{
    // Admin is the policy, Department is key, Administration is value
    options.AddPolicy("Admin", policy => policy.RequireClaim("Department", "Administration"));
});

var connstr = builder.Configuration.GetConnectionString("OfficeManagement");

// Configure EF Core for Identity
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(connstr);
});

// Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    // Set to false for now
    options.SignIn.RequireConfirmedEmail = false;

}).AddEntityFrameworkStores<AccountDbContext>();


builder.Services.AddDbContextFactory<OMSContext>(options =>
{
    options.UseSqlServer(connstr);
});


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


if (builder.Environment.IsEnvironment("TESTING"))
{
    // Making sure CSS Isolation works
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
builder.Services.AddTransient<IDeleteLejerUseCase, DeleteLejerUseCase>();

builder.Services.AddTransient<IViewMedarbejderByNameUseCase, ViewMedarbejderByNameUseCase>();
builder.Services.AddTransient<IAddMedarbejderUseCase, AddMedarbejderUseCase>();

builder.Services.AddTransient<IViewKontorhusByNameUseCase, ViewKontorhusByNameUseCase>();
builder.Services.AddTransient<IAddKontorhusUseCase, AddKontorhusUseCase>();
builder.Services.AddTransient<IViewKontorhusByIdUseCase, ViewKontorhusByIdUseCase>();
builder.Services.AddTransient<IEditKontorhusUseCase, EditKontorhusUseCase>();

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
