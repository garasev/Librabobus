using Librabobus.Backend.Repositories.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Librabobus.Backend.Repositories.Impl
{
    public static class ProviderExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRecordRepository, RecordRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            return services;
        }

    }
}