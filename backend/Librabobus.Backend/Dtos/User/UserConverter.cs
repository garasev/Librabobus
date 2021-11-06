using Librabobus.Backend.Models.User;

namespace Librabobus.Backend.Dtos.User
{
    public class UserConverter: IDtoConverter<UserModel, UserDto>
    {
        public UserModel Convert(UserDto dto) => new (
            id: dto.Id,
            name: dto.Name,
            about: dto.About!,
            photoBase64: dto.PhotoBase64!,
            login: dto.Login,
            password: dto.Password);

        public UserDto Convert(UserModel model) => new (
            id: model.Id,
            name: model.Name,
            about: model.About!,
            photoBase64: model.PhotoBase64!,
            login: model.Login,
            password: model.Password);
    }
}