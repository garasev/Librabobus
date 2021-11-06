using System;
using Librabobus.Backend.Models.Enums;
using Librabobus.Database.Enums;

namespace Librabobus.Backend.Models.Record
{
    public class RecordModelConverter: IModelConverter<RecordModel, Database.Models.Record>
    {
        public RecordModel Convert(Database.Models.Record dbModel)
        {
            return dbModel == null! ? null!: new RecordModel(
                id: dbModel.Id,
                subjectId: dbModel.SubjectId,
                name: dbModel.Name,
                type: (TypeRecordModel)dbModel.Type,
                content: dbModel.Content,
                keyWords: dbModel.KeyWords!
            );
        }

        public Database.Models.Record Convert(RecordModel model) => new(
            id: model.Id,
            subjectId: model.SubjectId,
            name: model.Name,
            type: (TypeRecord)model.Type,
            content: model.Content,
            keyWords: model.KeyWords!
        );
    }
}