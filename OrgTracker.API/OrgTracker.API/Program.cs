using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using OrgTracker.API.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using OrgTracker.API.Services;
using System.Text.Json.Serialization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<OrgTrackerDbContext>(options => 
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAnyOrigin", p => {
		p.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader();
	});
});

builder.Services
	.AddScoped<IEmployeeService, EmployeeService>()
	.AddScoped<ITaskService, TaskService>()
	.AddScoped<IReportService, ReportService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var context = services.GetRequiredService<OrgTrackerDbContext>();
		DbInitializer.Initialize(context);
	}
	catch (Exception)
	{
		throw;
	}
}

app.Run();
