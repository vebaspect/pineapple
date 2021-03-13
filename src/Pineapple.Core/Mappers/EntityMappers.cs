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

        public static EnvironmentDto ToDto(this Domain.Entities.Environment environment)
        {
            return new EnvironmentDto(
                environment.Id,
                environment.ModifiedDate,
                environment.IsDeleted,
                environment.Name,
                environment.Symbol,
                environment.Description,
                environment.OperatorId,
                environment.Operator.FullName
            );
        }

        public static ImplementationDto ToDto(this Domain.Entities.Implementation implementation)
        {
            return new ImplementationDto(
                implementation.Id,
                implementation.ModifiedDate,
                implementation.IsDeleted,
                implementation.Name,
                implementation.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ComponentLog log)
        {
            return new LogDto(
                log.Id,
                log.ModifiedDate,
                log.IsDeleted,
                log.Type,
                log.Category,
                log.OwnerId,
                log.Owner.FullName,
                log.ComponentId,
                log.Component.Name,
                log.Component.ProductId,
                log.Component.Product.Name,
                log.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ImplementationLog log)
        {
            return new LogDto(
                log.Id,
                log.ModifiedDate,
                log.IsDeleted,
                log.Type,
                log.Category,
                log.OwnerId,
                log.Owner.FullName,
                log.ImplementationId,
                log.Implementation.Name,
                null,
                null,
                log.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ProductLog productLog)
        {
            return new LogDto(
                productLog.Id,
                productLog.ModifiedDate,
                productLog.IsDeleted,
                productLog.Type,
                productLog.Category,
                productLog.OwnerId,
                productLog.Owner.FullName,
                productLog.ProductId,
                productLog.Product.Name,
                null,
                null,
                productLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.UserLog userLog)
        {
            return new LogDto(
                userLog.Id,
                userLog.ModifiedDate,
                userLog.IsDeleted,
                userLog.Type,
                userLog.Category,
                userLog.OwnerId,
                userLog.Owner.FullName,
                userLog.UserId,
                userLog.User.FullName,
                null,
                null,
                userLog.Description
            );
        }

        public static OperatingSystemDto ToDto(this Domain.Entities.OperatingSystem operatingSystem)
        {
            return new OperatingSystemDto(
                operatingSystem.Id,
                operatingSystem.ModifiedDate,
                operatingSystem.IsDeleted,
                operatingSystem.Name,
                operatingSystem.Symbol,
                operatingSystem.Description
            );
        }

        public static ProductDto ToDto(this Domain.Entities.Product product)
        {
            return new ProductDto(
                product.Id,
                product.ModifiedDate,
                product.IsDeleted,
                product.Name,
                product.Description
            );
        }

        public static ServerDto ToDto(this Domain.Entities.Server server)
        {
            return new ServerDto(
                server.Id,
                server.ModifiedDate,
                server.IsDeleted,
                server.Name,
                server.Symbol,
                server.Description,
                server.OperatingSystemId,
                server.OperatingSystem.Name,
                server.IpAddress
            );
        }

        public static SoftwareApplicationDto ToDto(this Domain.Entities.SoftwareApplication softwareApplication)
        {
            return new SoftwareApplicationDto(
                softwareApplication.Id,
                softwareApplication.ModifiedDate,
                softwareApplication.IsDeleted,
                softwareApplication.Name,
                softwareApplication.Symbol,
                softwareApplication.Description
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
