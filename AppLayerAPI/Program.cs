using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using DAL.Migrations;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        });
        builder.Services.AddScoped<DataAccessFactory>();
        builder.Services.AddScoped<INotification, InAppNotificationService>();
        builder.Services.AddScoped<AppointmentService>();

        builder.Services.AddScoped<UserService>();

        builder.Services.AddScoped<ProfessionalService>();


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
    }
}