using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pineapple.Core.Storage.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentTypes",
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
                        principalTable: "ComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Implementations",
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
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Environments",
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
                        principalTable: "Implementations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Environments_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Symbol = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    EnvironmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperatingSystemId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareApplicationId = table.Column<Guid>(type: "uuid", nullable: true),
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
                        principalTable: "Environments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servers_OperatingSystems_OperatingSystemId",
                        column: x => x.OperatingSystemId,
                        principalTable: "OperatingSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servers_SoftwareApplications_SoftwareApplicationId",
                        column: x => x.SoftwareApplicationId,
                        principalTable: "SoftwareApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
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
                        principalTable: "Components",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_ComponentTypes_ComponentTypeId",
                        column: x => x.ComponentTypeId,
                        principalTable: "ComponentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_ComponentVersions_ComponentVersionId",
                        column: x => x.ComponentVersionId,
                        principalTable: "ComponentVersions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Implementations_ImplementationId",
                        column: x => x.ImplementationId,
                        principalTable: "Implementations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_OperatingSystems_OperatingSystemId",
                        column: x => x.OperatingSystemId,
                        principalTable: "OperatingSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_SoftwareApplications_SoftwareApplicationId",
                        column: x => x.SoftwareApplicationId,
                        principalTable: "SoftwareApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServerComponents",
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
                        principalTable: "ComponentVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerComponents_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentTypeId",
                table: "Components",
                column: "ComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ProductId",
                table: "Components",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentTypes_Symbol",
                table: "ComponentTypes",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentVersions_ComponentId",
                table: "ComponentVersions",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_ImplementationId",
                table: "Environments",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_OperatorId",
                table: "Environments",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_Symbol",
                table: "Environments",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Implementations_ManagerId",
                table: "Implementations",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ComponentId",
                table: "Logs",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ComponentTypeId",
                table: "Logs",
                column: "ComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ComponentVersionId",
                table: "Logs",
                column: "ComponentVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_EnvironmentId",
                table: "Logs",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ImplementationId",
                table: "Logs",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_OperatingSystemId",
                table: "Logs",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_OwnerId",
                table: "Logs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ProductId",
                table: "Logs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ServerId",
                table: "Logs",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SoftwareApplicationId",
                table: "Logs",
                column: "SoftwareApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingSystems_Symbol",
                table: "OperatingSystems",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServerComponents_ComponentVersionId",
                table: "ServerComponents",
                column: "ComponentVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerComponents_ServerId",
                table: "ServerComponents",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_EnvironmentId",
                table: "Servers",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_OperatingSystemId",
                table: "Servers",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_SoftwareApplicationId",
                table: "Servers",
                column: "SoftwareApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_Symbol",
                table: "Servers",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareApplications_Symbol",
                table: "SoftwareApplications",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ServerComponents");

            migrationBuilder.DropTable(
                name: "ComponentVersions");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropTable(
                name: "OperatingSystems");

            migrationBuilder.DropTable(
                name: "SoftwareApplications");

            migrationBuilder.DropTable(
                name: "ComponentTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Implementations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
