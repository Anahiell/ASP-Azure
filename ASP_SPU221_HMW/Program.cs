using ASP_SPU221_HMW.Data.Context;
using ASP_SPU221_HMW.Data.Dal;
using ASP_SPU221_HMW.Services.Hash;
using ASP_SPU221_HMW.Services.Kdf;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//������������ ������� � ���������
builder.Services.AddSingleton<IRandCodeService,RandomCodeGenerator>();
builder.Services.AddSingleton<IKdfService, PasswordKdfService>();

builder.Services.AddDbContext<DataContext>(options=>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("MsSql")),
    ServiceLifetime.Singleton
);
builder.Services.AddSingleton<DataAcessor>();
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
