using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Extension
{
    public static class PostgreSqlServiceExtensions
    {
        public static void AddPostgreSqlDbContext(
this IServiceCollection services,
IConfiguration configuration
        )
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("PostgreSQLConnection"));
            });
        }


    }
}
