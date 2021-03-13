using Pineapple.Core.Dto;

namespace Pineapple.Core.Mappers
{
    /// <summary>
    /// Metody umożliwiające mapowanie encji na DTO.
    /// </summary>
    public static class EntityMappers
    {
        public static UserDto ToDto(this Domain.Entities.Administrator administrator)
        {
            return (administrator as Domain.Entities.User).ToDto();
        }

        public static UserDto ToDto(this Domain.Entities.Developer developer)
        {
            return (developer as Domain.Entities.User).ToDto();
        }

        public static UserDto ToDto(this Domain.Entities.Manager manager)
        {
            return (manager as Domain.Entities.User).ToDto();
        }

        public static UserDto ToDto(this Domain.Entities.Operator @operator)
        {
            return (@operator as Domain.Entities.User).ToDto();
        }

        public static UserDto ToDto(this Domain.Entities.User user)
        {
            return new UserDto(
                user.Id,
                user.ModifiedDate,
                user.IsDeleted,
                user.Type,
                user.FullName,
                user.Login,
                user.Phone,
                user.Email
            );
        }
    }
}
