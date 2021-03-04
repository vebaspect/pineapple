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
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ComponentVersionServer", b =>
                {
                    b.Property<Guid>("ComponentVersionsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServersId")
                        .HasColumnType("uuid");

                    b.HasKey("ComponentVersionsId", "ServersId");

                    b.HasIndex("ServersId");

                    b.ToTable("ComponentVersionServer");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Component", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ComponentTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ComponentTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTime>("ModifiedDate")
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

                    b.ToTable("ComponentTypes");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ComponentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<int>("Major")
                        .HasColumnType("integer");

                    b.Property<int>("Minor")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Patch")
                        .HasColumnType("integer");

                    b.Property<string>("PreRelease")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.ToTable("ComponentVersions");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Coordinator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("ImplementationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("ImplementationId");

                    b.ToTable("Coordinators");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Environment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<Guid>("ImplementationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("OperatorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("ImplementationId");

                    b.HasIndex("OperatorId");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("Environments");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Implementation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Implementations");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.OperatingSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTime>("ModifiedDate")
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

                    b.ToTable("OperatingSystems");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<Guid>("EnvironmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("IPAddress")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("ModifiedDate")
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

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.SoftwareApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTime>("ModifiedDate")
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

                    b.ToTable("SoftwareApplications");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("ModifiedDate")
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

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Type").HasValue("User");
                });

            modelBuilder.Entity("ServerSoftwareApplication", b =>
                {
                    b.Property<Guid>("ServersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SoftwareApplicationsId")
                        .HasColumnType("uuid");

                    b.HasKey("ServersId", "SoftwareApplicationsId");

                    b.HasIndex("SoftwareApplicationsId");

                    b.ToTable("ServerSoftwareApplication");
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

            modelBuilder.Entity("ComponentVersionServer", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.ComponentVersion", null)
                        .WithMany()
                        .HasForeignKey("ComponentVersionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.Server", null)
                        .WithMany()
                        .HasForeignKey("ServersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Component", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.ComponentType", "ComponentType")
                        .WithMany("Components")
                        .HasForeignKey("ComponentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.Product", "Product")
                        .WithMany("Components")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComponentType");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentVersion", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Component", "Component")
                        .WithMany("ComponentVersions")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Component");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Coordinator", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Implementation", "Implementation")
                        .WithMany("Coordinators")
                        .HasForeignKey("ImplementationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Implementation");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Environment", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Implementation", "Implementation")
                        .WithMany("Environments")
                        .HasForeignKey("ImplementationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.Operator", "Operator")
                        .WithMany("Environments")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Implementation");

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Server", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Environment", "Environment")
                        .WithMany("Servers")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.OperatingSystem", "OperatingSystem")
                        .WithMany("Servers")
                        .HasForeignKey("OperatingSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Environment");

                    b.Navigation("OperatingSystem");
                });

            modelBuilder.Entity("ServerSoftwareApplication", b =>
                {
                    b.HasOne("Pineapple.Core.Domain.Entities.Server", null)
                        .WithMany()
                        .HasForeignKey("ServersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pineapple.Core.Domain.Entities.SoftwareApplication", null)
                        .WithMany()
                        .HasForeignKey("SoftwareApplicationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Component", b =>
                {
                    b.Navigation("ComponentVersions");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.ComponentType", b =>
                {
                    b.Navigation("Components");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Environment", b =>
                {
                    b.Navigation("Servers");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Implementation", b =>
                {
                    b.Navigation("Coordinators");

                    b.Navigation("Environments");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.OperatingSystem", b =>
                {
                    b.Navigation("Servers");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Product", b =>
                {
                    b.Navigation("Components");
                });

            modelBuilder.Entity("Pineapple.Core.Domain.Entities.Operator", b =>
                {
                    b.Navigation("Environments");
                });
#pragma warning restore 612, 618
        }
    }
}
