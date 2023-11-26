using ChampManage.API;
using ChampManage.API.Data;
using ChampManage.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChampManageContext>(DbContextOptions =>
         DbContextOptions.UseSqlite(
              builder.Configuration["ConnectionStrings:ChampManageDBConnectionString"]));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IChampionshipRepository, ChampionshipRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]))
        };
    }
);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("user_type", UserType.Admin.ToString());
    });

    options.AddPolicy("OrganizerOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("user_type", UserType.Organizer.ToString());
    });

    options.AddPolicy("AdminOrOrganizerOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context =>
        {
            var userTypeClaim = context.User.FindFirst("user_type")?.Value;
            return userTypeClaim == UserType.Admin.ToString() || userTypeClaim == UserType.Organizer.ToString();
        });
    });

    options.AddPolicy("ParticipantOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("user_type", UserType.Participant.ToString());
    });
    options.AddPolicy("RegisteredUserOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

var allowReactApp = "AllowReactApp";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowReactApp,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowReactApp);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
