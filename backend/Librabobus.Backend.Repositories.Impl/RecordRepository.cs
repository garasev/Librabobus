using System;
using System.Linq;
using System.Threading.Tasks;
using Librabobus.Backend.Models.Enums;
using Librabobus.Backend.Models.Record;
using Librabobus.Backend.Repositories.Api;
using Librabobus.Database;
using Microsoft.EntityFrameworkCore;

namespace Librabobus.Backend.Repositories.Impl
{
    public class RecordRepository: IRecordRepository
    {
        readonly private LibrabobusDbContext _context;

        public RecordRepository(LibrabobusDbContext context)
        {
            _context = context;
        }

        public async Task<RecordModel> GetRecordAsync(Guid id)
        {
            var record = await _context.Record!
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            
            return new RecordModel(
                id: record.Id,
                name: record.Name,
                type: (TypeRecord)record.Type,
                content: record.Content,
                keyWords: record.KeyWords!
            );
        }
    }
}