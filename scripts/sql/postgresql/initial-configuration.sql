-- Włączenie obsługi UUID:

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Administratorzy:

INSERT INTO
    public."Users"("Id", "Type", "FullName", "Login", "Phone", "Email", "ModifiedDate", "IsDeleted")
	VALUES ('00000000-0000-0000-0000-000000000000', 'Administrator', 'Administrator', 'admin', NULL, NULL, NOW(), false);

-- Typy komponentów:

INSERT INTO
    public."ComponentTypes"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Aplikacja webowa (.NET Core)', 'netcorewebapp', NULL, NOW(), false);
INSERT INTO
    public."ComponentTypes"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Aplikacja webowa (PHP)', 'phpwebapp', NULL, NOW(), false);
INSERT INTO
    public."ComponentTypes"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Aplikacja desktopowa (.NET Core)', 'netcoredesktopapp', NULL, NOW(), false);
INSERT INTO
    public."ComponentTypes"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Aplikacja konsolowa (.NET Core)', 'netcoreconsoleapp', NULL, NOW(), false);

-- Systemy operacyjne:

INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Windows 7', 'windows7', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Windows 8.1', 'windows8.1', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Windows 10', 'windows10', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Windows Server 2008', 'windowsserver2008', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Windows Server 2008 R2', 'windowsserver2008r2', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Windows Server 2012', 'windowsserver2012', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Windows Server 2012 R2', 'windowsserver2012r2', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Windows Server 2016', 'windowsserver2016', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Windows Server 2019', 'windowsserver2019', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Oracle Linux 8.0', 'oraclelinux80', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Oracle Linux 8.1', 'oraclelinux81', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Oracle Linux 8.2', 'oraclelinux82', NULL, NOW(), false);
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Oracle Linux 8.3', 'oraclelinux83', NULL, NOW(), false);

-- Oprogramowanie:

INSERT INTO
    public."SoftwareApplications"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Baza danych (SQL Server 2008)', 'sqlserver2008', NULL, NOW(), false);
INSERT INTO
    public."SoftwareApplications"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Baza danych (SQL Server 2008 R2)', 'sqlserver2008r2', NULL, NOW(), false);
INSERT INTO
    public."SoftwareApplications"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Baza danych (SQL Server 2012)', 'sqlserver2012', NULL, NOW(), false);
INSERT INTO
    public."SoftwareApplications"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Baza danych (SQL Server 2014)', 'sqlserver2014', NULL, NOW(), false);
INSERT INTO
    public."SoftwareApplications"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Baza danych (SQL Server 2016)', 'sqlserver2016', NULL, NOW(), false);
INSERT INTO
    public."SoftwareApplications"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Baza danych (SQL Server 2017)', 'sqlserver2017', NULL, NOW(), false);
INSERT INTO
    public."SoftwareApplications"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Baza danych (SQL Server 2019)', 'sqlserver2019', NULL, NOW(), false);
INSERT INTO
    public."SoftwareApplications"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Baza danych (Oracle Database 21c)', 'oracledatabase21c', NULL, NOW(), false);
INSERT INTO
    public."SoftwareApplications"("Id", "Name", "Symbol", "Description", "ModifiedDate", "IsDeleted")
	VALUES (uuid_generate_v4(), 'Baza danych (PostgreSQL 13)', 'postgresql13', NULL, NOW(), false);
