using Librabobus.Backend.Dtos.Record;
using Librabobus.Backend.Dtos.Subject;
using Librabobus.Backend.Dtos.User;
using Librabobus.Backend.Models.Record;
using Librabobus.Backend.Models.Subject;
using Librabobus.Backend.Models.User;
using Microsoft.Extensions.DependencyInjection;

namespace Librabobus.Backend.Dtos
{
    public static class ProvideExtension
    {
        public static IServiceCollection AddDtoConverters(this IServiceCollection services)
        {
            services.AddTransient<IDtoConverter<UserPageModel, UserPageDto>, UserPageConverter>();
            services.AddTransient<IDtoConverter<RecordModel, RecordDto>, RecordConverter>();
            services.AddTransient<IDtoConverter<SubjectModel, SubjectDto>, SubjectConverter>();
            services.AddTransient<IDtoConverter<UserSubModel, UserSubDto>, UserSubConverter>();

            return services;
        }
    }
}