using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
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

builder.Services.AddTransient<IAnimalServices, AnimalServices>();
builder.Services.AddTransient<IPersonServices, PersonServices>();

builder.Services.AddTransient<IInProcessAnimalRepository, InProcessAnimalRepository>();
builder.Services.AddTransient<IInProcessPeopleRepository, InProcessPeopleRepository>();

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
