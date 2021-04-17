using System.Collections.Generic;
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
                component.CreationDate,
                component.ModificationDate,
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
                componentType.CreationDate,
                componentType.ModificationDate,
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
                componentVersion.CreationDate,
                componentVersion.ModificationDate,
                componentVersion.IsDeleted,
                componentVersion.Major,
                componentVersion.Minor,
                componentVersion.Patch,
                componentVersion.Suffix,
                componentVersion.Description
            );
        }

        public static CoordinatorDto ToDto(this Domain.Entities.Coordinator coordinator)
        {
            return new CoordinatorDto(
                coordinator.Id,
                coordinator.CreationDate,
                coordinator.ModificationDate,
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
                environment.CreationDate,
                environment.ModificationDate,
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
                implementation.CreationDate,
                implementation.ModificationDate,
                implementation.IsDeleted,
                implementation.Name,
                implementation.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ComponentLog componentLog)
        {
            return new LogDto(
                componentLog.Id,
                componentLog.CreationDate,
                componentLog.ModificationDate,
                componentLog.IsDeleted,
                componentLog.Type,
                componentLog.Category,
                componentLog.OwnerId,
                componentLog.Owner.FullName,
                new EntityDto(
                    componentLog.ComponentId,
                    componentLog.Component.Name
                ),
                new List<EntityDto>()
                {
                    new EntityDto(
                        componentLog.Component.ProductId,
                        componentLog.Component.Product.Name
                    ),
                },
                componentLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ComponentTypeLog componentTypeLog)
        {
            return new LogDto(
                componentTypeLog.Id,
                componentTypeLog.CreationDate,
                componentTypeLog.ModificationDate,
                componentTypeLog.IsDeleted,
                componentTypeLog.Type,
                componentTypeLog.Category,
                componentTypeLog.OwnerId,
                componentTypeLog.Owner.FullName,
                new EntityDto(
                    componentTypeLog.ComponentTypeId,
                    componentTypeLog.ComponentType.Name
                ),
                null,
                componentTypeLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ComponentVersionLog componentVersionLog)
        {
            return new LogDto(
                componentVersionLog.Id,
                componentVersionLog.CreationDate,
                componentVersionLog.ModificationDate,
                componentVersionLog.IsDeleted,
                componentVersionLog.Type,
                componentVersionLog.Category,
                componentVersionLog.OwnerId,
                componentVersionLog.Owner.FullName,
                new EntityDto(
                    componentVersionLog.ComponentVersionId,
                    componentVersionLog.ComponentVersion.GetFormattedNumber()
                ),
                new List<EntityDto>()
                {
                    new EntityDto(
                        componentVersionLog.ComponentVersion.ComponentId,
                        componentVersionLog.ComponentVersion.Component.Name
                    ),
                    new EntityDto(
                        componentVersionLog.ComponentVersion.Component.ProductId,
                        componentVersionLog.ComponentVersion.Component.Product.Name
                    ),
                },
                componentVersionLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.EnvironmentLog environmentLog)
        {
            return new LogDto(
                environmentLog.Id,
                environmentLog.CreationDate,
                environmentLog.ModificationDate,
                environmentLog.IsDeleted,
                environmentLog.Type,
                environmentLog.Category,
                environmentLog.OwnerId,
                environmentLog.Owner.FullName,
                new EntityDto(
                    environmentLog.EnvironmentId,
                    environmentLog.Environment.Name
                ),
                new List<EntityDto>()
                {
                    new EntityDto(
                        environmentLog.Environment.ImplementationId,
                        environmentLog.Environment.Implementation.Name
                    ),
                },
                environmentLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ImplementationLog implementationLog)
        {
            return new LogDto(
                implementationLog.Id,
                implementationLog.CreationDate,
                implementationLog.ModificationDate,
                implementationLog.IsDeleted,
                implementationLog.Type,
                implementationLog.Category,
                implementationLog.OwnerId,
                implementationLog.Owner.FullName,
                new EntityDto(
                    implementationLog.ImplementationId,
                    implementationLog.Implementation.Name
                ),
                null,
                implementationLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.OperatingSystemLog operatingSystemLog)
        {
            return new LogDto(
                operatingSystemLog.Id,
                operatingSystemLog.CreationDate,
                operatingSystemLog.ModificationDate,
                operatingSystemLog.IsDeleted,
                operatingSystemLog.Type,
                operatingSystemLog.Category,
                operatingSystemLog.OwnerId,
                operatingSystemLog.Owner.FullName,
                new EntityDto(
                    operatingSystemLog.OperatingSystemId,
                    operatingSystemLog.OperatingSystem.Name
                ),
                null,
                operatingSystemLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ProductLog productLog)
        {
            return new LogDto(
                productLog.Id,
                productLog.CreationDate,
                productLog.ModificationDate,
                productLog.IsDeleted,
                productLog.Type,
                productLog.Category,
                productLog.OwnerId,
                productLog.Owner.FullName,
                new EntityDto(
                    productLog.ProductId,
                    productLog.Product.Name
                ),
                null,
                productLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ServerLog serverLog)
        {
            return new LogDto(
                serverLog.Id,
                serverLog.CreationDate,
                serverLog.ModificationDate,
                serverLog.IsDeleted,
                serverLog.Type,
                serverLog.Category,
                serverLog.OwnerId,
                serverLog.Owner.FullName,
                new EntityDto(
                    serverLog.ServerId,
                    serverLog.Server.Name
                ),
                new List<EntityDto>()
                {
                    new EntityDto(
                        serverLog.Server.EnvironmentId,
                        serverLog.Server.Environment.Name
                    ),
                    new EntityDto(
                        serverLog.Server.Environment.ImplementationId,
                        serverLog.Server.Environment.Implementation.Name
                    ),
                },
                serverLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.SoftwareApplicationLog softwareApplicationLog)
        {
            return new LogDto(
                softwareApplicationLog.Id,
                softwareApplicationLog.CreationDate,
                softwareApplicationLog.ModificationDate,
                softwareApplicationLog.IsDeleted,
                softwareApplicationLog.Type,
                softwareApplicationLog.Category,
                softwareApplicationLog.OwnerId,
                softwareApplicationLog.Owner.FullName,
                new EntityDto(
                    softwareApplicationLog.SoftwareApplicationId,
                    softwareApplicationLog.SoftwareApplication.Name
                ),
                null,
                softwareApplicationLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.UserLog userLog)
        {
            return new LogDto(
                userLog.Id,
                userLog.CreationDate,
                userLog.ModificationDate,
                userLog.IsDeleted,
                userLog.Type,
                userLog.Category,
                userLog.OwnerId,
                userLog.Owner.FullName,
                new EntityDto(
                    userLog.UserId,
                    userLog.User.FullName
                ),
                null,
                userLog.Description
            );
        }

        public static OperatingSystemDto ToDto(this Domain.Entities.OperatingSystem operatingSystem)
        {
            return new OperatingSystemDto(
                operatingSystem.Id,
                operatingSystem.CreationDate,
                operatingSystem.ModificationDate,
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
                product.CreationDate,
                product.ModificationDate,
                product.IsDeleted,
                product.Name,
                product.Description
            );
        }

        public static ServerDto ToDto(this Domain.Entities.Server server)
        {
            return new ServerDto(
                server.Id,
                server.CreationDate,
                server.ModificationDate,
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
                softwareApplication.CreationDate,
                softwareApplication.ModificationDate,
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
                user.CreationDate,
                user.ModificationDate,
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
