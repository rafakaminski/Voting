using Microsoft.EntityFrameworkCore;
using Voting.Repository;
using Voting.Repository.Repository;
using Voting.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VotingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddScoped<VotesRepository>();
builder.Services.AddScoped<VotesService>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
