using BOL;
using BOL.Data;
using DAL;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var str = builder.Configuration.GetConnectionString("constr");
builder.Services.AddDbContext<HBS_DBContext>(options => options.UseSqlServer(str));

builder.Services.AddScoped<Istaff, StaffDAL>();
builder.Services.AddScoped<IGust, GustDAL>();
builder.Services.AddScoped<IBooking, BookingDAL>();
builder.Services.AddScoped<IRoom, RoomDAL>();
builder.Services.AddScoped<IRoomClass, RoomClassDAL>();

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
