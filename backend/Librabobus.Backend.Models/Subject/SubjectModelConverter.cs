using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Librabobus.Backend.Models.Record;

namespace Librabobus.Backend.Models.Subject
{
    public class SubjectModelConverter: IModelConverter<SubjectModel, Database.Models.Subject>
    {
        private readonly RecordModelConverter _recordModelConverter = new RecordModelConverter();
        public SubjectModel Convert(Database.Models.Subject dbModel)
        {
            List<RecordModel> records = dbModel.Records is not null ? dbModel.Records!
                .Select(record => _recordModelConverter.Convert(record))
                .ToList(): null!; 
            
            return dbModel == null! ? null!: new SubjectModel(
                id: dbModel.Id,
                ownerId: dbModel.OwnerId,
                name: dbModel.Name,
                privat: dbModel.Privat,
                description: dbModel.Description!,
                photoBase64: dbModel.PhotoBase64!,
                records: records
            ); 
        }

        public Database.Models.Subject Convert(SubjectModel model) => new(
            id: model.Id,
            ownerId: model.OwnerId,
            name: model.Name,
            privat: model.Privat,
            description: model.Description!,
            photoBase64: model.PhotoBase64
        ); 
    }
    
}