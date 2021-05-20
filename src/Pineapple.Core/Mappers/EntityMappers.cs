using System.Collections.Generic;
using System.Linq;
using Pineapple.Core.Dto;
using Pineapple.Core.Dto.Logs;

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
                component.ComponentType.Name,
                component.GetLatestVersion()?.Id,
                component.GetLatestVersion()?.GetFormattedNumber()
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
                componentVersion.GetKind(),
                componentVersion.ReleaseDate,
                componentVersion.Major,
                componentVersion.Minor,
                componentVersion.Patch,
                componentVersion.Suffix,
                componentVersion.Description
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
                environment.Operator?.FullName
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
                implementation.Description,
                implementation.ManagerId,
                implementation.Manager?.FullName
            );
        }

        public static ILogDto ToDto(this Domain.Entities.ComponentLog componentLog)
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
                new ExtendedEntityDto(
                    componentLog.ComponentId,
                    componentLog.Component.Name,
                    null
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
                new ExtendedEntityDto(
                    componentTypeLog.ComponentTypeId,
                    componentTypeLog.ComponentType.Name,
                    null
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
                new ExtendedEntityDto(
                    componentVersionLog.ComponentVersionId,
                    componentVersionLog.ComponentVersion.GetFormattedNumber(),
                    null
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
                new ExtendedEntityDto(
                    environmentLog.EnvironmentId,
                    environmentLog.Environment.Name,
                    null
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
                new ExtendedEntityDto(
                    implementationLog.ImplementationId,
                    implementationLog.Implementation.Name,
                    null
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
                new ExtendedEntityDto(
                    operatingSystemLog.OperatingSystemId,
                    operatingSystemLog.OperatingSystem.Name,
                    null
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
                new ExtendedEntityDto(
                    productLog.ProductId,
                    productLog.Product.Name,
                    null
                ),
                null,
                productLog.Description
            );
        }

        public static LogDto ToDto(this Domain.Entities.ServerLog serverLog)
        {
            return serverLog.Type switch
            {
                "ServerComponentLog" => new LogDto(
                    serverLog.Id,
                    serverLog.CreationDate,
                    serverLog.ModificationDate,
                    serverLog.IsDeleted,
                    serverLog.Type,
                    serverLog.Category,
                    serverLog.OwnerId,
                    serverLog.Owner.FullName,
                    new ExtendedEntityDto(
                        serverLog.ServerId,
                        serverLog.Server.Name,
                        new EntityDetailsDto
                        {
                            ServerComponent = new ServerComponentEntityDetailsDto
                            {
                                ProductId = ((Domain.Entities.ServerComponentLog)serverLog).ServerComponentVersion.Component.ProductId,
                                ProductName = ((Domain.Entities.ServerComponentLog)serverLog).ServerComponentVersion.Component.Product.Name,
                                ComponentId = ((Domain.Entities.ServerComponentLog)serverLog).ServerComponentVersion.ComponentId,
                                ComponentName = ((Domain.Entities.ServerComponentLog)serverLog).ServerComponentVersion.Component.Name,
                                ComponentVersionId = ((Domain.Entities.ServerComponentLog)serverLog).ServerComponentVersionId,
                                ComponentVersionNumber = ((Domain.Entities.ServerComponentLog)serverLog).ServerComponentVersion.GetFormattedNumber()
                            }
                        }
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
                ),
                "ServerSoftwareApplicationLog" => new LogDto(
                    serverLog.Id,
                    serverLog.CreationDate,
                    serverLog.ModificationDate,
                    serverLog.IsDeleted,
                    serverLog.Type,
                    serverLog.Category,
                    serverLog.OwnerId,
                    serverLog.Owner.FullName,
                    new ExtendedEntityDto(
                        serverLog.ServerId,
                        serverLog.Server.Name,
                        new EntityDetailsDto
                        {
                            ServerSoftwareApplication = new ServerSoftwareApplicationEntityDetailsDto
                            {
                                SoftwareApplicationId = ((Domain.Entities.ServerSoftwareApplicationLog)serverLog).ServerSoftwareApplicationId,
                                SoftwareApplicationName = ((Domain.Entities.ServerSoftwareApplicationLog)serverLog).ServerSoftwareApplication.Name
                            }
                        }
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
                ),
                _ => new LogDto(
                    serverLog.Id,
                    serverLog.CreationDate,
                    serverLog.ModificationDate,
                    serverLog.IsDeleted,
                    serverLog.Type,
                    serverLog.Category,
                    serverLog.OwnerId,
                    serverLog.Owner.FullName,
                    new ExtendedEntityDto(
                        serverLog.ServerId,
                        serverLog.Server.Name,
                        null
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
              ),
            };
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
                new ExtendedEntityDto(
                    softwareApplicationLog.SoftwareApplicationId,
                    softwareApplicationLog.SoftwareApplication.Name,
                    null
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
                new ExtendedEntityDto(
                    userLog.UserId,
                    userLog.User.FullName,
                    null
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
                server.IpAddress,
                server.Description,
                server.OperatingSystemId,
                server.OperatingSystem.Name,
                server
                    .InstalledComponents?
                    .OrderBy(installedComponent => installedComponent.ComponentVersion.Component.Product.Name)
                    .ThenBy(installedComponent => installedComponent.ComponentVersion.Component.Name)
                    .Select(installedComponent =>
                    {
                        return new InstalledComponentDto(
                            installedComponent.Id,
                            installedComponent.ComponentVersion.Component.ProductId,
                            installedComponent.ComponentVersion.Component.Product.Name,
                            installedComponent.ComponentVersion.ComponentId,
                            installedComponent.ComponentVersion.Component.Name,
                            installedComponent.ComponentVersionId,
                            installedComponent.ComponentVersion.GetFormattedNumber(),
                            installedComponent.ComponentVersion != installedComponent.ComponentVersion.Component.GetLatestVersion()
                        );
                    })
                    .ToList(),
                server
                    .InstalledSoftwareApplications?
                    .OrderBy(installedSoftwareApplication => installedSoftwareApplication.SoftwareApplication.Name)
                    .Select(installedSoftwareApplication =>
                    {
                        return new InstalledSoftwareApplicationDto(
                            installedSoftwareApplication.Id,
                            installedSoftwareApplication.SoftwareApplicationId,
                            installedSoftwareApplication.SoftwareApplication.Name
                        );
                    })
                    .ToList()
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
