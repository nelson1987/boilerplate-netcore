using Stargazer.Application;
using Stargazer.Infrastructure;
using Stargazer.WebApi.Middlewares;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Stargazer.WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

//builder.Services
//    .AddIdentityCore<AppUser>()
//    .AddEntityFrameworkStores


builder.Services.AddInfrastructure(builder.Configuration)
                .AddApplication();

builder.Services.AddControllers(x =>
    {
        x.Filters.Add(typeof(ValidateModelAttribute));
    })
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddFluentValidationRulesToSwagger();

builder.Services.ConfigureHttpsRedirection();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapIdentityApi<AppUser>();

app.Run();
//docker run -dp 8080:8080 webapi
//docker build -t webapi . --no-cache