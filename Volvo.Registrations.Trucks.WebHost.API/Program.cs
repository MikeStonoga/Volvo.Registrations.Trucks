using Hangfire;
using MediatR;
using Volvo.Registrations.Trucks.Application.Commons.Events.Handlers;
using Volvo.Registrations.Trucks.Hangfire;
using Volvo.Registrations.Trucks.WebHost.API.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(type => type.FullName?.Replace("+", ".")));

builder.Services.AddCors(options =>
    options.AddPolicy("DefaultCorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod())
);
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.RegisterDependencies(builder.Configuration);

builder.Services.AddMediatR(typeof(EventHandler<,>));
builder.Services.AddHangfire(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();
var backgroundJobClient = app.Services.GetRequiredService<IBackgroundJobClient>();
app.UseHangfire(backgroundJobClient);
app.MapControllers();

app.ApplyMigrations();

app.Run();
