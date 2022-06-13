using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using SharedGarden.API.Exceptions;
using SharedGarden.API.Handler;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

var domain = $"https://{configuration["Auth0:Domain"]}/";

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ApiExceptionFilterAttribute());
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
    options.ReturnHttpNotAcceptable = true;
}).AddFluentValidation();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = domain;
    options.Audience = configuration["Auth0:Audience"];
});

builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
});

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

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
