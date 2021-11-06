using Librabobus.Backend.Models.Record;
using Librabobus.Backend.Models.Subject;
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
            
            services.AddTransient<IModelConverter<SubjectModel, Database.Models.Subject>,
                SubjectModelConverter>();
            return services;
        }
    }
}