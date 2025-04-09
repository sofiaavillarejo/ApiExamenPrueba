using ApiExamenPrueba.Data;
using ApiExamenPrueba.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddDbContext<CubosContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<RepositoryCubos>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerDocument(config =>
{
    config.DocumentName = "v1";
    config.Title = "Api Cubos";
    config.Version = "v1";
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Api Departamentos");
    options.RoutePrefix = "";
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
