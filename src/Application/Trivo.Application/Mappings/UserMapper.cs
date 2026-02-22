using Trivo.Application.DTOs.User;

namespace Trivo.Application.Mappings;

public static class UserMapper
{
    public static UserDto MapUserDto(Domain.Models.User user)
    {
        return new UserDto(
            Id: user.Id,
            FirstName: user.FirstName,
            LastName: user.LastName,
            ProfilePictureUrl: user.ProfilePicture
        );
    }
}