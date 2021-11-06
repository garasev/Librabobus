using System.Collections.Generic;
using System.Linq;
using Librabobus.Backend.Dtos.Subject;
using Librabobus.Backend.Dtos.Record;
using Librabobus.Backend.Models.Enums;
using Librabobus.Backend.Models.Record;
using Librabobus.Backend.Models.Subject;

namespace Librabobus.Backend.Dtos.Subject
{
    public class SubjectConverter: IDtoConverter<SubjectModel, SubjectDto>
    {
        private readonly RecordConverter _recordConverter = new RecordConverter();
        public SubjectModel Convert(SubjectDto dto)
        {
            List<RecordModel> records = dto.Records is not null ? dto.Records!
                .Select(record => _recordConverter.Convert(record))
                .ToList(): null!; 
            
            return new SubjectModel(
                id: dto.Id,
                ownerId: dto.OwnerId,
                name: dto.Name,
                privat: dto.Privat,
                description: dto.Description!,
                photoBase64: dto.PhotoBase64!,
                records: records
            ); 
        } 
        
        public SubjectDto Convert(SubjectModel model)
        {
            List<RecordDto> records = model.Records is not null ? model.Records!
                .Select(record => _recordConverter.Convert(record))
                .ToList(): null!; 
                
            return new SubjectDto(
                id: model.Id,
                ownerId: model.OwnerId,
                name: model.Name,
                privat: model.Privat,
                description: model.Description!,
                photoBase64: model.PhotoBase64!,
                records: records
            ); 
        }
    }
}