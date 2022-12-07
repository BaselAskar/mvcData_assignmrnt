using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Data;
using mvcData_assignmrnt.Repositories;
using mvcData_assignmrnt.Repositories.Implemnting;
using mvcData_assignmrnt.Repositories.Implemting;
using mvcData_assignmrnt.Services;
using mvcData_assignmrnt.Services.Implementing;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDataInitializer, DataInitializer>();
builder.Services.AddScoped<IPeopleRepo,PeopleRepo>();
builder.Services.AddScoped<ICitiesReop, CitiesRepo>();
builder.Services.AddScoped<ICountriesRepo, CountriesRepo>();
builder.Services.AddScoped<ILanguageRepo,LanguageRepo>();

builder.Services.AddScoped<IPeopleService,PeopleService>();
builder.Services.AddScoped<ICountriesService,CountriesService>();
builder.Services.AddScoped<ILanguageService,LanguageService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
{
    var services = scope.ServiceProvider;
    IDataInitializer initializer = services.GetRequiredService<IDataInitializer>();
    initializer.Seed();
}
    




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
