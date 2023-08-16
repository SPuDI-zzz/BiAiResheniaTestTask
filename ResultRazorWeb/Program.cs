using ResultRazorWeb.Services;
using ResultRazorWeb.Services.IService;
using ResultRazorWeb.Utility;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddHttpContextAccessor();
services.AddHttpClient();

services.AddHttpClient<ISumOfEverySecondOddNumberService, SumOfEverySecondOddNumberService>();
services.AddHttpClient<IPalindromeService, PalindromeService>();
services.AddHttpClient<ISortNumbersService, SortNumbersService>();

SD.DataAccessWebApi = configuration["ServiceUrls:DataAccessWebApi"]!;

services.AddScoped<IBaseService, BaseService>();
services.AddScoped<ISumOfEverySecondOddNumberService, SumOfEverySecondOddNumberService>();
services.AddScoped<IPalindromeService, PalindromeService>();
services.AddScoped<ISortNumbersService, SortNumbersService>();

services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
