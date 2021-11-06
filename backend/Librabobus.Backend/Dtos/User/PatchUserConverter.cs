using System;
using Librabobus.Backend.Models.User;

namespace Librabobus.Backend.Dtos.User
{
    public class PatchUserConverter: IDtoConverter<PatchUserModel, PatchUserDto>
    {
        public PatchUserDto Convert(PatchUserModel model) => new (
            name: model.Name!,
            about: model.About!,
            photoBase64: model.PhotoBase64!,
            login: model.Login!,
            password: model.Password!);

        public PatchUserModel Convert(PatchUserDto dto) => new (
            name: dto.Name,
            about: dto.About,
            photoBase64: dto.PhotoBase64,
            login: dto.Login,
            password: dto.Password
            );
    }
}