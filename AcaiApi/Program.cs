using AcaiStoreApi.Models;
using AcaiStoreApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AcaiStoreDatabaseSettings>(
    builder.Configuration.GetSection("AcaiStoreDatabase"));

builder.Services.AddSingleton<AcaisService>();

#region [cors]
builder.Services.AddCors();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region [cors]
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
