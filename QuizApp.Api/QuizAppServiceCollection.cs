using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using QuizApp.Api.Data;

namespace QuizApp.Api
{
    public static class QuizAppServiceCollection
    {
        public static IServiceCollection AddQuizAppService(this IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlServer();
            });
            // Services
            services.AddScoped<IRegisteredServices, RegisteredServices>();
            return services;
        }
    }
}
