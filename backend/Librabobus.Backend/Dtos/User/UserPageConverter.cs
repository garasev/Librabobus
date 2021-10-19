using System.Linq;
using Librabobus.Backend.Dtos.Subject;
using Librabobus.Backend.Models.Subject;
using Librabobus.Backend.Models.User;

namespace Librabobus.Backend.Dtos.User
{
    public class UserPageConverter: IDtoConverter<UserPageModel, UserPageDto>
    {
        public UserPageModel Convert(UserPageDto dto) => new(id: dto.Id,
            name: dto.Name,
            about: dto.About!,
            photoBase64: dto.PhotoBase64!,
            login: dto.Login,
            countSubscribers: dto.CountSubscribers,
            countSubscriptions: dto.CountSubscriptions,
            subjects: dto.Subjects.Select(
                sub => new SubjectPreviewModel(id: sub.Id, name: sub.Name, photoBase64: sub.PhotoBase64!)
            ).ToList());
        
        public UserPageDto Convert(UserPageModel model) => new(id: model.Id,
            name: model.Name,
            about: model.About!,
            photoBase64: model.PhotoBase64!,
            login: model.Login,
            countSubscribers: model.CountSubscribers,
            countSubscriptions: model.CountSubscriptions,
            subjects: model.Subjects.Select(
                sub => new SubjectPreviewDto(id: sub.Id, name: sub.Name, photoBase64: sub.PhotoBase64!)
            ).ToList());
    }
}