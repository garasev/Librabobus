using System;
using Librabobus.Backend.Models.User;

namespace Librabobus.Backend.Dtos.User
{
    public class UserSubConverter: IDtoConverter<UserSubModel, UserSubDto>
    {
        public UserSubModel Convert(UserSubDto dto) => new (
            id: dto.Id,
            name: dto.Name,
            photoBase64: dto.PhotoBase64!
            );

        public UserSubDto Convert(UserSubModel model) => new (
            id: model.Id,
            name: model.Name,
            photoBase64: model.PhotoBase64!
        );
    }
}