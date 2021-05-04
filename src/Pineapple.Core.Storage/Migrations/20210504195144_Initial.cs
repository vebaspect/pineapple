using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pineapple.Core.Storage.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pineapple");

            migrationBuilder.CreateTable(
                name: "ComponentTypes",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Symbol = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Symbol = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareApplications",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Symbol = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Login = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComponentTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_ComponentTypes_ComponentTypeId",
                        column: x => x.ComponentTypeId,
                        principalSchema: "pineapple",
                        principalTable: "ComponentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Components_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "pineapple",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Implementations",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implementations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Implementations_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalSchema: "pineapple",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComponentVersions",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Major = table.Column<int>(type: "integer", nullable: false),
                    Minor = table.Column<int>(type: "integer", nullable: false),
                    Patch = table.Column<int>(type: "integer", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentVersions_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalSchema: "pineapple",
                        principalTable: "Components",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Environments",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Symbol = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    ImplementationId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Environments_Implementations_ImplementationId",
                        column: x => x.ImplementationId,
                        principalSchema: "pineapple",
                        principalTable: "Implementations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Environments_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalSchema: "pineapple",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Symbol = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    EnvironmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperatingSystemId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servers_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalSchema: "pineapple",
                        principalTable: "Environments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Servers_OperatingSystems_OperatingSystemId",
                        column: x => x.OperatingSystemId,
                        principalSchema: "pineapple",
                        principalTable: "OperatingSystems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ComponentTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    ComponentVersionId = table.Column<Guid>(type: "uuid", nullable: true),
                    EnvironmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ImplementationId = table.Column<Guid>(type: "uuid", nullable: true),
                    OperatingSystemId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    ServerId = table.Column<Guid>(type: "uuid", nullable: true),
                    ServerComponentVersionId = table.Column<Guid>(type: "uuid", nullable: true),
                    ServerSoftwareApplicationId = table.Column<Guid>(type: "uuid", nullable: true),
                    SoftwareApplicationId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalSchema: "pineapple",
                        principalTable: "Components",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_ComponentTypes_ComponentTypeId",
                        column: x => x.ComponentTypeId,
                        principalSchema: "pineapple",
                        principalTable: "ComponentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_ComponentVersions_ComponentVersionId",
                        column: x => x.ComponentVersionId,
                        principalSchema: "pineapple",
                        principalTable: "ComponentVersions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_ComponentVersions_ServerComponentVersionId",
                        column: x => x.ServerComponentVersionId,
                        principalSchema: "pineapple",
                        principalTable: "ComponentVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalSchema: "pineapple",
                        principalTable: "Environments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Implementations_ImplementationId",
                        column: x => x.ImplementationId,
                        principalSchema: "pineapple",
                        principalTable: "Implementations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_OperatingSystems_OperatingSystemId",
                        column: x => x.OperatingSystemId,
                        principalSchema: "pineapple",
                        principalTable: "OperatingSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "pineapple",
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Servers_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "pineapple",
                        principalTable: "Servers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_SoftwareApplications_ServerSoftwareApplicationId",
                        column: x => x.ServerSoftwareApplicationId,
                        principalSchema: "pineapple",
                        principalTable: "SoftwareApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_SoftwareApplications_SoftwareApplicationId",
                        column: x => x.SoftwareApplicationId,
                        principalSchema: "pineapple",
                        principalTable: "SoftwareApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "pineapple",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "pineapple",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServerComponents",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComponentVersionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServerComponents_ComponentVersions_ComponentVersionId",
                        column: x => x.ComponentVersionId,
                        principalSchema: "pineapple",
                        principalTable: "ComponentVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerComponents_Servers_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "pineapple",
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServerSoftwareApplications",
                schema: "pineapple",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareApplicationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerSoftwareApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServerSoftwareApplications_Servers_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "pineapple",
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerSoftwareApplications_SoftwareApplications_SoftwareApp~",
                        column: x => x.SoftwareApplicationId,
                        principalSchema: "pineapple",
                        principalTable: "SoftwareApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentTypeId",
                schema: "pineapple",
                table: "Components",
                column: "ComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ProductId",
                schema: "pineapple",
                table: "Components",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentTypes_Symbol",
                schema: "pineapple",
                table: "ComponentTypes",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentVersions_ComponentId",
                schema: "pineapple",
                table: "ComponentVersions",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_ImplementationId",
                schema: "pineapple",
                table: "Environments",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_OperatorId",
                schema: "pineapple",
                table: "Environments",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Implementations_ManagerId",
                schema: "pineapple",
                table: "Implementations",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ComponentId",
                schema: "pineapple",
                table: "Logs",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ComponentTypeId",
                schema: "pineapple",
                table: "Logs",
                column: "ComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ComponentVersionId",
                schema: "pineapple",
                table: "Logs",
                column: "ComponentVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_EnvironmentId",
                schema: "pineapple",
                table: "Logs",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ImplementationId",
                schema: "pineapple",
                table: "Logs",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_OperatingSystemId",
                schema: "pineapple",
                table: "Logs",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_OwnerId",
                schema: "pineapple",
                table: "Logs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ProductId",
                schema: "pineapple",
                table: "Logs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ServerComponentVersionId",
                schema: "pineapple",
                table: "Logs",
                column: "ServerComponentVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ServerId",
                schema: "pineapple",
                table: "Logs",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ServerSoftwareApplicationId",
                schema: "pineapple",
                table: "Logs",
                column: "ServerSoftwareApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SoftwareApplicationId",
                schema: "pineapple",
                table: "Logs",
                column: "SoftwareApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                schema: "pineapple",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingSystems_Symbol",
                schema: "pineapple",
                table: "OperatingSystems",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServerComponents_ComponentVersionId",
                schema: "pineapple",
                table: "ServerComponents",
                column: "ComponentVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerComponents_ServerId",
                schema: "pineapple",
                table: "ServerComponents",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_EnvironmentId",
                schema: "pineapple",
                table: "Servers",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_OperatingSystemId",
                schema: "pineapple",
                table: "Servers",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSoftwareApplications_ServerId",
                schema: "pineapple",
                table: "ServerSoftwareApplications",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSoftwareApplications_SoftwareApplicationId",
                schema: "pineapple",
                table: "ServerSoftwareApplications",
                column: "SoftwareApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareApplications_Symbol",
                schema: "pineapple",
                table: "SoftwareApplications",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                schema: "pineapple",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "ServerComponents",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "ServerSoftwareApplications",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "ComponentVersions",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "Servers",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "SoftwareApplications",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "Components",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "Environments",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "OperatingSystems",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "ComponentTypes",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "Implementations",
                schema: "pineapple");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "pineapple");
        }
    }
}
