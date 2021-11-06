using Librabobus.Backend.Models.Record;
using Microsoft.Extensions.DependencyInjection;

namespace Librabobus.Backend.Models
{
    public static class ProviderExtension
    {
        /// <summary>
        /// Метод расширение для добавления конвертеров моделей
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddModelConverters(this IServiceCollection services)
        {
            services.AddTransient<IModelConverter<RecordModel, Database.Models.Record>,
                RecordModelConverter>();
            return services;
        }
    }
}