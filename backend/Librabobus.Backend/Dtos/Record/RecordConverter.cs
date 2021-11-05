using Librabobus.Backend.Models.Enums;
using Librabobus.Backend.Models.Record;

namespace Librabobus.Backend.Dtos.Record
{
    public class RecordConverter: IDtoConverter<RecordModel, RecordDto>
    {
        public RecordModel Convert(RecordDto dto) => new(id: dto.Id,
            name: dto.Name,
            type: (TypeRecord)dto.Type,
            content: dto.Content,
            keyWords: dto.KeyWords!
        );

        public RecordDto Convert(RecordModel model) => new(id: model.Id,
            name: model.Name,
            type: (int)model.Type,
            content: model.Content,
            keyWords: model.KeyWords!
        );
    }
}