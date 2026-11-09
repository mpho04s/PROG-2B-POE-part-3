
using RaceDayMVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Configure the RaceDayAPI connection
var apiUrl = builder.Configuration["UserApi:BaseUrl"];

if (string.IsNullOrWhiteSpace(apiUrl))
{
    throw new InvalidOperationException(
        "RaceDayAPI BaseUrl is missing from appsettings.json.");
}

builder.Services.AddHttpClient<RaceDayApiService>(client =>
{
    client.BaseAddress = new Uri(apiUrl);
});

var app = builder.Build();

// Configure the application
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
