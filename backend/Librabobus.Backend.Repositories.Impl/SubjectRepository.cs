using System;
using System.Linq;
using System.Threading.Tasks;
using Librabobus.Backend.Models;
using Librabobus.Backend.Models.Record;
using Librabobus.Backend.Repositories.Api;
using Librabobus.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Librabobus.Backend.Models.Subject;
using Librabobus.Backend.Repositories.Impl.Exceptions;
using Librabobus.Database.Models;

namespace Librabobus.Backend.Repositories.Impl
{
    public class SubjectRepository: ISubjectRepository
    {
        readonly private LibrabobusDbContext _context;
        readonly private IModelConverter<SubjectModel, Database.Models.Subject> _converter;

        public SubjectRepository(LibrabobusDbContext context,
            IModelConverter<SubjectModel, Database.Models.Subject> converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<SubjectModel> FindSubjectAsync(Guid id)
        {
            var subject = await _context.Subject!
                .Where(u => u.Id == id)
                .Include(u => u.Records)
                .FirstOrDefaultAsync();

            return _converter.Convert(subject);
        }
        
        public async Task<List<SubjectModel>> FindAllSubjectAsync()
        {
            var subjects = await _context.Subject!
                .Include(u => u.Records)
                .ToListAsync();
            
            return subjects.Select(subject => _converter.Convert(subject)).ToList();
        }
        
        public async Task<SubjectModel> AddSubjectAsync(SubjectModel subjectModel)
        {
            var dbSubjectModel = _converter.Convert(subjectModel);
            
            var uniqSubjectCheck = await _context.Subject!
                .AnyAsync(subject => subject.Id == dbSubjectModel.Id);
            
            if (uniqSubjectCheck)
                throw new RepositoryConflictException("Subject with such Id already exists");
            
            var entityEntry = await _context.Subject!.AddAsync(dbSubjectModel);
            await _context.SaveChangesAsync();
            return _converter.Convert(entityEntry.Entity);
        }
        
        public async Task<SubjectModel> UpdateSubjectAsync(SubjectModel updateSubjectModel)
        {
            var dbSubjectModel = _converter.Convert(updateSubjectModel);
            
            var subject = await _context.Subject!
                .Where(c => c.Id == dbSubjectModel.Id)
                .FirstOrDefaultAsync();
            
            if (subject == null) 
                throw new NotFoundException($"Subject with such ID is not found.");

            subject = dbSubjectModel;
            
            await _context.SaveChangesAsync();
            return _converter.Convert(subject!);
        }
        
        public async Task<SubjectModel> DeleteSubjectAsync(Guid id)
        {
            var subject = await _context.Subject!
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            var subjectModel = _converter.Convert(subject!);
            
            if (subject != null)
            {
                _context.Subject!.Remove(subject);
                await _context.SaveChangesAsync();
            }

            return subjectModel;
        }

    }
}