using Librabobus.Backend.Models.Enums;
using Librabobus.Backend.Models.Record;

namespace Librabobus.Backend.Dtos.Record
{
    public class RecordConverter: IDtoConverter<RecordModel, RecordDto>
    {
        public RecordModel Convert(RecordDto dto) => new(id: dto.Id,
            subjectId: dto.SubjectId,
            name: dto.Name,
            type: (TypeRecordModel)dto.Type,
            content: dto.Content,
            keyWords: dto.KeyWords!
        );
        public RecordDto Convert(RecordModel model)
        {
            return model == null! ? null! : new RecordDto(id: model.Id,
                subjectId: model.SubjectId,
                name: model.Name,
                type: (int)model.Type,
                content: model.Content,
                keyWords: model.KeyWords!
            );
        }
    }
}