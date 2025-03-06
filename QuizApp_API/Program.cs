using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuizApp_API.Data;
using QuizApp_API.Models;
using Swashbuckle.AspNetCore.Filters;
using QuizApp_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionStringQuestions = builder.Configuration.GetConnectionString("QuizApp")!;
string connectionStringUsers = builder.Configuration.GetConnectionString("QuizAppUsers")!;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionStringQuestions, ServerVersion.AutoDetect(connectionStringQuestions)));

// Register QuestionService
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Add Authentication
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

// Add Authorization
builder.Services.AddAuthorizationBuilder();

// Configure DBContext
builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseMySql(connectionStringUsers,
        ServerVersion.AutoDetect(connectionStringUsers)));

builder.Services.AddIdentityCore<AppUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.WithOrigins("http://localhost:5174")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapIdentityApi<AppUser>();

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