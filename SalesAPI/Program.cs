using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContextes;
using Microsoft.OpenApi.Models;
using SalesAPI.Hubs; // Add this using directive

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddDbContext<ClientsContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DemoCompany")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
app.MapHub<ChatHub>("/chat-hub");
app.MapControllers();

app.Run();
