
using MedTrackDash.Data;
using MedTrackDash.Extensions;
using MedTrackDash.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Extensions.Logging;
namespace MedTrackDash
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddOpenApiDocument();

			// Add services to the container.
			builder.Services.AddControllers();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddTransient<IPatientDatabaseService, PatientDatabaseService>();
			builder.Services.AddTransient<IDoctorDatabaseService, DoctorDatabaseService>();
			builder.Services.AddTransient<IAppointmentDatabaseService, AppointmentDatabaseService>();

			var connectionString = builder.Configuration.GetConnectionString("AppContext");
			builder.Services.AddDbContext<MedTrackContext>(options =>
			
				// options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MedTrackDashInMemoryDb"));
				options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
					options => options.EnableRetryOnFailure(
						maxRetryCount: 5,
						maxRetryDelay: System.TimeSpan.FromSeconds(30),
						errorNumbersToAdd: null)
					));

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: "MyAllowSpecificOrigins",
					builder =>
					{
						builder.WithOrigins("http://localhost:4200")
							.AllowAnyHeader()
							.AllowAnyMethod();
					});
			});

			var log = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Configuration)
				.CreateLogger();

			builder.Services.AddSerilog(log);
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				//app.UseSwagger();
				//app.UseSwaggerUI();
				app.UseOpenApi();     // use in place of app.UseSwagger()
				app.UseSwaggerUi();
			}

			app.UseHttpsRedirection();

			app.UseCors("MyAllowSpecificOrigins");

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
