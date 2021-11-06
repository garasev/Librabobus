using System.Collections;
using System.Collections.Generic;
using Librabobus.Backend.Models.Record;

namespace Librabobus.Backend.Models.Subject
{
    public class SubjectModelConverter: IModelConverter<SubjectModel, Database.Models.Subject>
    {
        public SubjectModel Convert(Database.Models.Subject dbModel)
        {
            return dbModel == null! ? null!: new SubjectModel(
                id: dbModel.Id,
                ownerId: dbModel.OwnerId,
                name: dbModel.Name,
                privat: dbModel.Privat,
                description: dbModel.Description!,
                photoBase64: dbModel.PhotoBase64!,
                records: (List<RecordModel>)dbModel.Records!
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