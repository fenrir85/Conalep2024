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

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));
var mysqlconnectionString = builder.Configuration.GetConnectionString("MysqlConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContextMySQL>(options =>
options.UseMySQL(mysqlconnectionString));
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseMySQL("MysqlConnection"));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(connectionString));
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

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddTransient<IrepositoryMySQL, RepositoryMySQL>();


builder.Services.AddBlazorDownloadFile();


AddBlazorise(builder.Services);



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
