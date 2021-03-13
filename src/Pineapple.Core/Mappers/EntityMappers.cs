using Pineapple.Core.Dto;

namespace Pineapple.Core.Mappers
{
    /// <summary>
    /// Metody umożliwiające mapowanie encji na DTO.
    /// </summary>
    public static class EntityMappers
    {
        public static ComponentDto ToDto(this Domain.Entities.Component component)
        {
            return new ComponentDto(
                component.Id,
                component.ModifiedDate,
                component.IsDeleted,
                component.Name,
                component.Description,
                component.ComponentTypeId,
                component.ComponentType.Name
            );
        }

        public static ComponentTypeDto ToDto(this Domain.Entities.ComponentType componentType)
        {
            return new ComponentTypeDto(
                componentType.Id,
                componentType.ModifiedDate,
                componentType.IsDeleted,
                componentType.Name,
                componentType.Symbol,
                componentType.Description
            );
        }

        public static ComponentVersionDto ToDto(this Domain.Entities.ComponentVersion componentVersion)
        {
            return new ComponentVersionDto(
                componentVersion.Id,
                componentVersion.ModifiedDate,
                componentVersion.IsDeleted,
                componentVersion.Major,
                componentVersion.Minor,
                componentVersion.Patch,
                componentVersion.PreRelease,
                componentVersion.Description
            );
        }

        public static CoordinatorDto ToDto(this Domain.Entities.Coordinator coordinator)
        {
            return new CoordinatorDto(
                coordinator.Id,
                coordinator.ModifiedDate,
                coordinator.IsDeleted,
                coordinator.FullName,
                coordinator.Phone,
                coordinator.Email
            );
        }

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
