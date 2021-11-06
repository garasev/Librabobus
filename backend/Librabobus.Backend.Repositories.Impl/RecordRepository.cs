using System;
using System.Linq;
using System.Threading.Tasks;
using Librabobus.Backend.Models;
using Librabobus.Backend.Models.Record;
using Librabobus.Backend.Repositories.Api;
using Librabobus.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Librabobus.Backend.Repositories.Impl.Exceptions;

namespace Librabobus.Backend.Repositories.Impl
{
    public class RecordRepository: IRecordRepository
    {
        readonly private LibrabobusDbContext _context;
        readonly private IModelConverter<RecordModel, Database.Models.Record> _converter;

        public RecordRepository(LibrabobusDbContext context,
            IModelConverter<RecordModel, Database.Models.Record> converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<RecordModel> FindRecordAsync(Guid id)
        {
            var record = await _context.Record!
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            
            return _converter.Convert(record);
        }
        public async Task<List<RecordModel>> FindAllRecordAsync()
        {
            var records = await _context.Record!.ToListAsync();

            return records.Select(record => _converter.Convert(record)).ToList();
        }
        public async Task<RecordModel> AddRecordAsync(RecordModel recordModel)
        {
            var dbRecordModel = _converter.Convert(recordModel);
            
            var uniqRecordCheck = await _context.Record!
                .AnyAsync(record => record.Id == dbRecordModel.Id);
            
            if (uniqRecordCheck)
                throw new RepositoryConflictException("Recor with such Id already exists");
            
            var entityEntry = await _context.Record!.AddAsync(dbRecordModel);
            await _context.SaveChangesAsync();
            return _converter.Convert(entityEntry.Entity);
        }
        public async Task<RecordModel> UpdateRecordAsync(RecordModel updateRecordModel)
        {
            var dbRecordModel = _converter.Convert(updateRecordModel);
            
            var record = await _context.Record!
                .Where(c => c.Id == dbRecordModel.Id)
                .FirstOrDefaultAsync();
            
            if (record == null) 
                throw new NotFoundException($"Record with such ID is not found.");

            record = dbRecordModel ;
            
            await _context.SaveChangesAsync();
            return _converter.Convert(record!);
        }
        public async Task<RecordModel> DeleteRecordAsync(Guid id)
        {
            var record = await _context.Record!
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            var recordModel = _converter.Convert(record!);
            
            if (record != null)
            {
                _context.Record!.Remove(record);
                await _context.SaveChangesAsync();
            }

            return recordModel;
        }

    }
}