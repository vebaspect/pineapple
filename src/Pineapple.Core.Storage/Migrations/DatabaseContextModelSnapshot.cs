﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pineapple.Core.Storage.Database;

namespace Pineapple.Core.Storage.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Component", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ComponentTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LicensesRepositoryPath")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("PackagesRepositoryPath")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("SourceCodeRepositoryUrl")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.HasKey("Id");

                    b.HasIndex("ComponentTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("Components", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("ComponentTypes", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ComponentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsImportant")
                        .HasColumnType("boolean");

                    b.Property<string>("IssueTrackingSystemTicketUrl")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<int>("Major")
                        .HasColumnType("integer");

                    b.Property<int>("Minor")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Patch")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Suffix")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.ToTable("ComponentVersions", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Environment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<Guid>("ImplementationId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid?>("OperatorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("ImplementationId");

                    b.HasIndex("OperatorId");

                    b.ToTable("Environments", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Implementation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Implementations", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Logs", "pineapple");

                    b.HasDiscriminator<string>("Type").HasValue("Log");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.OperatingSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("OperatingSystems", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Products", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<Guid>("EnvironmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("IpAddress")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("OperatingSystemId")
                        .HasColumnType("uuid");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("OperatingSystemId");

                    b.ToTable("Servers", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerComponent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ComponentVersionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ComponentVersionId");

                    b.HasIndex("ServerId");

                    b.ToTable("ServerComponents", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerSoftwareApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SoftwareApplicationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.HasIndex("SoftwareApplicationId");

                    b.ToTable("ServerSoftwareApplications", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.SoftwareApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("SoftwareApplications", "pineapple");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users", "pineapple");

                    b.HasDiscriminator<string>("Type").HasValue("User");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("ComponentId")
                        .HasColumnType("uuid");

                    b.HasIndex("ComponentId");

                    b.HasDiscriminator().HasValue("ComponentLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentTypeLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("ComponentTypeId")
                        .HasColumnType("uuid");

                    b.HasIndex("ComponentTypeId");

                    b.HasDiscriminator().HasValue("ComponentTypeLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentVersionLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("ComponentVersionId")
                        .HasColumnType("uuid");

                    b.HasIndex("ComponentVersionId");

                    b.HasDiscriminator().HasValue("ComponentVersionLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.EnvironmentLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("EnvironmentId")
                        .HasColumnType("uuid");

                    b.HasIndex("EnvironmentId");

                    b.HasDiscriminator().HasValue("EnvironmentLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ImplementationLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("ImplementationId")
                        .HasColumnType("uuid");

                    b.HasIndex("ImplementationId");

                    b.HasDiscriminator().HasValue("ImplementationLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.OperatingSystemLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("OperatingSystemId")
                        .HasColumnType("uuid");

                    b.HasIndex("OperatingSystemId");

                    b.HasDiscriminator().HasValue("OperatingSystemLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ProductLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasIndex("ProductId");

                    b.HasDiscriminator().HasValue("ProductLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uuid");

                    b.HasIndex("ServerId");

                    b.HasDiscriminator().HasValue("ServerLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.SoftwareApplicationLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("SoftwareApplicationId")
                        .HasColumnType("uuid");

                    b.HasIndex("SoftwareApplicationId");

                    b.HasDiscriminator().HasValue("SoftwareApplicationLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.UserLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.Log");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("UserLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Administrator", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Developer", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Developer");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Manager", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Operator", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Operator");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerComponentLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.ServerLog");

                    b.Property<Guid>("ServerComponentVersionId")
                        .HasColumnType("uuid");

                    b.HasIndex("ServerComponentVersionId");

                    b.HasDiscriminator().HasValue("ServerComponentLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerSoftwareApplicationLog", b =>
                {
                    b.HasBaseType("Pineapple.Core.Domain.Entities.ServerLog");

                    b.Property<Guid>("ServerSoftwareApplicationId")
                        .HasColumnType("uuid");

                    b.HasIndex("ServerSoftwareApplicationId");

                    b.HasDiscriminator().HasValue("ServerSoftwareApplicationLog");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Component", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.ComponentType", "ComponentType")
                        .WithMany("Components")
                        .HasForeignKey("ComponentTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.Product", "Product")
                        .WithMany("Components")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ComponentType");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentVersion", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Component", "Component")
                        .WithMany("ComponentVersions")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Component");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Environment", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Implementation", "Implementation")
                        .WithMany("Environments")
                        .HasForeignKey("ImplementationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.Operator", "Operator")
                        .WithMany("Environments")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Implementation");

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Implementation", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Manager", "Manager")
                        .WithMany("Implementations")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Log", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.User", "Owner")
                        .WithMany("OwnedLogs")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Server", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Environment", "Environment")
                        .WithMany("Servers")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.OperatingSystem", "OperatingSystem")
                        .WithMany("Servers")
                        .HasForeignKey("OperatingSystemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Environment");

                    b.Navigation("OperatingSystem");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerComponent", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.ComponentVersion", "ComponentVersion")
                        .WithMany("Servers")
                        .HasForeignKey("ComponentVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.Server", "Server")
                        .WithMany("InstalledComponents")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComponentVersion");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerSoftwareApplication", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Server", "Server")
                        .WithMany("InstalledSoftwareApplications")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.SoftwareApplication", "SoftwareApplication")
                        .WithMany("Servers")
                        .HasForeignKey("SoftwareApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");

                    b.Navigation("SoftwareApplication");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Component", "Component")
                        .WithMany("EntityLogs")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Component");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentTypeLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.ComponentType", "ComponentType")
                        .WithMany("EntityLogs")
                        .HasForeignKey("ComponentTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ComponentType");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentVersionLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.ComponentVersion", "ComponentVersion")
                        .WithMany("EntityLogs")
                        .HasForeignKey("ComponentVersionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ComponentVersion");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.EnvironmentLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Environment", "Environment")
                        .WithMany("EntityLogs")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Environment");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ImplementationLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Implementation", "Implementation")
                        .WithMany("EntityLogs")
                        .HasForeignKey("ImplementationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Implementation");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.OperatingSystemLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.OperatingSystem", "OperatingSystem")
                        .WithMany("EntityLogs")
                        .HasForeignKey("OperatingSystemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("OperatingSystem");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ProductLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Product", "Product")
                        .WithMany("EntityLogs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Server", "Server")
                        .WithMany("EntityLogs")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.SoftwareApplicationLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.SoftwareApplication", "SoftwareApplication")
                        .WithMany("EntityLogs")
                        .HasForeignKey("SoftwareApplicationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SoftwareApplication");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.UserLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.User", "User")
                        .WithMany("EntityLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerComponentLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.ComponentVersion", "ServerComponentVersion")
                        .WithMany()
                        .HasForeignKey("ServerComponentVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServerComponentVersion");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ServerSoftwareApplicationLog", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.SoftwareApplication", "ServerSoftwareApplication")
                        .WithMany()
                        .HasForeignKey("ServerSoftwareApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServerSoftwareApplication");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Component", b =>
                {
                    b.Navigation("ComponentVersions");

                    b.Navigation("EntityLogs");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentType", b =>
                {
                    b.Navigation("Components");

                    b.Navigation("EntityLogs");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentVersion", b =>
                {
                    b.Navigation("EntityLogs");

                    b.Navigation("Servers");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Environment", b =>
                {
                    b.Navigation("EntityLogs");

                    b.Navigation("Servers");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Implementation", b =>
                {
                    b.Navigation("EntityLogs");

                    b.Navigation("Environments");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.OperatingSystem", b =>
                {
                    b.Navigation("EntityLogs");

                    b.Navigation("Servers");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Product", b =>
                {
                    b.Navigation("Components");

                    b.Navigation("EntityLogs");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Server", b =>
                {
                    b.Navigation("EntityLogs");

                    b.Navigation("InstalledComponents");

                    b.Navigation("InstalledSoftwareApplications");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.SoftwareApplication", b =>
                {
                    b.Navigation("EntityLogs");

                    b.Navigation("Servers");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.User", b =>
                {
                    b.Navigation("EntityLogs");

                    b.Navigation("OwnedLogs");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Manager", b =>
                {
                    b.Navigation("Implementations");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Operator", b =>
                {
                    b.Navigation("Environments");
                });
#pragma warning restore 612, 618
        }
    }
}
