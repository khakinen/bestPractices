using System;
using System.Collections.Generic;
using System.Text;
using BestPractices.EF.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.EF.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DBConnection");
            var keepAliveConnection = new SqliteConnection(connectionString);
            keepAliveConnection.Open();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUow, Uow>();

            return services;
        }

       
    }
}
// dotnet ef migrations add inital_migration --project BestPractices.EF.Data/BestPractices.EF.Data.csproj --startup-project BestPractices.EF.Api/BestPractices.EF.Api.csproj