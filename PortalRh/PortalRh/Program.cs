using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortalRh.Data;
using PortalRh.Areas.Identity;
using PortalRh.Repository;
using BlazorDownloadFile;
using PortalRh.Models;
using PortalRh;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var mysqlconnectionString = builder.Configuration.GetConnectionString("MysqlConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContextMySQL>(options =>
options.UseMySQL(mysqlconnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContextMySQL>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
//builder.Services.AddTransient<MySqlDataService>();
//builder.Services.AddScoped<RegNominasService>();
builder.Services.AddTransient<SericaHeaderModel>();
builder.Services.AddTransient<SericaDetalleReporteModel>();
builder.Services.AddTransient<PartidasModel>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddTransient<IrepositoryMySQL, RepositoryMySQL>();

builder.Services.AddScoped<FileService>();

builder.Services.AddBlazorDownloadFile();

AddBlazorise(builder.Services);

var defaultCulture = new CultureInfo("es-MX");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = new List<CultureInfo> { defaultCulture };
    options.SupportedUICultures = new List<CultureInfo> { defaultCulture };
});


var app = builder.Build();
app.UseRequestLocalization(localizationOptions);

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

app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

void AddBlazorise(IServiceCollection services)
{
    services
        .AddBlazorise();
    services
        .AddBootstrap5Providers()
        .AddFontAwesomeIcons();
}
