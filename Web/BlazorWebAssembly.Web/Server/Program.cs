using BlazaorWebAssembly.Services;
using BlazaorWebAssembly.Services.Interfaces;
using BlazorWebAssembly.Data;
using BlazorWebAssembly.Data.Models.ApplicationModels;
using BlazorWebAssembly.Data.Seeding;
using BlazorWebAssembly.Services.Mapping;
using BlazorWebAssembly.Services.Messaging;
using BlazorWebAssembly.Services.Messaging.Interfaces;
using BlazorWebAssembly.Web.Shared;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                {
                    const string OpenId = "openid";

                    options.IdentityResources[OpenId].UserClaims.Add(JwtClaimTypes.Email);
                    options.ApiResources.Single().UserClaims.Add(JwtClaimTypes.Email);

                    options.IdentityResources[OpenId].UserClaims.Add(JwtClaimTypes.Role);
                    options.ApiResources.Single().UserClaims.Add(JwtClaimTypes.Role);
                });

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove(JwtClaimTypes.Role);

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Uncomment as you configure Cloudinary in appsettings.json

//var account = new Account
//           (
//               builder.Configuration["Cloudinary:AppName"],
//               builder.Configuration["Cloudinary:AppKey"],
//               builder.Configuration["Cloudinary:AppSecret"]
//      );

//Cloudinary cloudinary = new Cloudinary(account);
//cloudinary.Api.Secure = true;

//Application services

//Uncomment as you type SendGridApiKey in appsettings.json

//builder.Services.AddTransient<IEmailSender>(
//                serviceProvider => new SendGridEmailSender(builder.Configuration["SendGrid:ApiKey"]));
builder.Services.AddTransient<IDemoService, DemoService>();
builder.Services.AddTransient<IEmailSender, NullMessageSender>();

//builder.Services.AddSingleton(cloudinary);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var serviceScope = app.Services.CreateScope())
{
    AutoMapperConfiguration.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
    IServiceProvider serviceProvider = serviceScope.ServiceProvider;
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    ApplicationDbInitialiser.SeedRoles(roleManager);
    ApplicationDbInitialiser.SeedUsers(userManager);
    DemoSeed.SeedDemos(dbContext);

}
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
