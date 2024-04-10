using Microsoft.EntityFrameworkCore;
using IncidentReport.Model;
using IncidentReport.Data;
using IncidentReport.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IncidentContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("debstar");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

/* builder.Services.AddDefaultIdentity<IdentityUser>(options => 
options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IncidentReportIdentityDbContext>(); */
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
