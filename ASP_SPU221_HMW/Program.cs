using ASP_SPU221_HMW.Data.Context;
using ASP_SPU221_HMW.Data.Dal;
using ASP_SPU221_HMW.Middleware;
using ASP_SPU221_HMW.Services.Hash;
using ASP_SPU221_HMW.Services.Kdf;
using ASP_SPU221_HMW.Services.Upload;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//регестрируем сервисы в контейнер
builder.Services.AddSingleton<IRandCodeService,RandomCodeGenerator>();
builder.Services.AddSingleton<IHashService, ShaHashService>();
builder.Services.AddSingleton<IKdfService, PasswordKdfService>();
builder.Services.AddSingleton<IUploadService, UploadServiceV1>();

builder.Services.AddDbContext<DataContext>(options=>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("MsSql")),
    ServiceLifetime.Singleton
);
builder.Services.AddSingleton<DataAccessor>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession();
app.UseSessionAuth();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
