using FastFood.DAL.Interface;
using FastFood.DAL.Models;
using FastFood.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
string? _connStr = builder.Configuration.GetConnectionString("FastFood_Db");

builder.Services.AddScoped<IRepository<Employee>>(
   p =>
   {
       return new EmployeeDapperRepository(_connStr);
   });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
