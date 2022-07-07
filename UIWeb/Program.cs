using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models.AnimalModels;
using Domain.Models.PersonModels;
using Domain.Services;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole(); // would usually write to a configured database.
});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IServices<Animal>, AnimalServices>();
builder.Services.AddTransient<IServices<Person>, PersonServices>();

builder.Services.AddSingleton<IRepository<Animal>, AnimalRepository>();
builder.Services.AddSingleton<IRepository<Person>, PeopleRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
