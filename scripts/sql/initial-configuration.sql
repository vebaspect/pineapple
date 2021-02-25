-- Włączenie obsługi UUID:

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Systemy operacyjne:

INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Windows 7', 'windows7', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Windows 8.1', 'windows8.1', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Windows 10', 'windows10', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Windows Server 2008', 'windowsserver2008', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Windows Server 2008 R2', 'windowsserver2008r2', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Windows Server 2012', 'windowsserver2012', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Windows Server 2012 R2', 'windowsserver2012r2', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Windows Server 2016', 'windowsserver2016', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Windows Server 2019', 'windowsserver2019', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Oracle Linux 8.0', 'oraclelinux80', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Oracle Linux 8.1', 'oraclelinux81', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Oracle Linux 8.2', 'oraclelinux82', NULL, NOW());
INSERT INTO
    public."OperatingSystems"("Id", "Name", "Symbol", "Description", "ModifiedDate")
	VALUES (uuid_generate_v4(), 'Oracle Linux 8.3', 'oraclelinux83', NULL, NOW());
