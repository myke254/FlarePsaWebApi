using Flare.Data.Entities;
using Flare.Repo;
using Flare.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<AppDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Flare"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));

builder.Services.AddScoped<IRepository<ListingModel>, Repository<ListingModel>>();
builder.Services.AddScoped<IRepository<CategoryModel>, Repository<CategoryModel>>();
builder.Services.AddScoped<IRepository<ReviewModel>, Repository<ReviewModel>>();
builder.Services.AddScoped<IRepository<UserModel>, Repository<UserModel>>();



var app = builder.Build();

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
