using System;
using System.Threading.Tasks;
using Librabobus.Backend.Models.Record;

namespace Librabobus.Backend.Repositories.Api
{
    public interface IRecordRepository
    {
        Task<RecordModel> GetRecordAsync(Guid id);
    }
}