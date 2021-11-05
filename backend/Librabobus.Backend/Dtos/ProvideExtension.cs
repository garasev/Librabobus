using Librabobus.Backend.Dtos.User;
using Librabobus.Backend.Models.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Librabobus.Backend.Dtos
{
    public static class ProvideExtension
    {
        public static IServiceCollection AddDtoConverters(this IServiceCollection services)
        {
            services.AddTransient<IDtoConverter<UserPageModel, UserPageDto>, UserPageConverter>();
            services.AddTransient<IDtoConverter<UserSubModel, UserSubDto>, UserSubConverter>();
            return services;
        }
    }
}