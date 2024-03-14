
using Microsoft.EntityFrameworkCore;
using SchoolProSite.DAL.Context;
using SchoolProSite.DAL.Dao;
using SchoolProSite.DAL.Interfaces;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region "Registro del contexto"
IServiceCollection serviceCollection = builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));
#endregion

#region "Registro de componentes Daos"

builder.Services.AddTransient<IDaoDepartment, DaoDepartment>();
builder.Services.AddTransient<IDaoCourse, DaoCourse>();

#endregion
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
