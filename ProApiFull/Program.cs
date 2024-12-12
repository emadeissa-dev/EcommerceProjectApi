using ProApiFull.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.





builder.Services.AddDepenencesConfig(builder.Configuration);
builder.Services.AddDependencesInfrastacture();
builder.Services.AddDependencesService();

builder.Services.AddDependencesService();

builder.AddSerilogConfig();

var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
app.AddMiddleWarePipeLine();


await app.AddDependencesServicePipeLine();





app.Run();
