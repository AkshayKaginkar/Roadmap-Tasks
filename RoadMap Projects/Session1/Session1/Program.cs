using Microsoft.Extensions.Hosting.Internal;
using Session1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string message = builder.Configuration.GetSection("Message").GetValue("Key", "no value");
builder.Services.AddSingleton<IProductService, ProductService>();

//setting above message value as a environment variable
//Environment.SetEnvironmentVariable("Message", message); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  
    app.UseHsts();
}

app.UseExceptionHandler("/Home/GolbalErrorHandler");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
