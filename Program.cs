using Microsoft.EntityFrameworkCore;
using IncidentReport.Model;
using IncidentReport.Data;
using IncidentReport.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddDbContext<IncidentContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("debstar");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<IncidentReportIdentityDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("debstar");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});



builder.Services.AddDefaultIdentity<IdentityUser>(options => 
options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IncidentReportIdentityDbContext>();
builder.Services.AddRazorPages();



builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<IdentityUser>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
