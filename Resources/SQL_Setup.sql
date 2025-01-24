-- Create the ClientInfo database if it doesn't exist
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'ClientInfo')
BEGIN
    CREATE DATABASE ClientInfo;
    PRINT 'ClientInfo database created successfully.';
END
ELSE
BEGIN
    PRINT 'ClientInfo database already exists.';
END
GO

-- Use the ClientInfo database
USE ClientInfo;
GO

-- Drop existing view if it exists
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'GetClientData' AND type = 'V')
    DROP VIEW GetClientData;
GO

-- Create the GetClientData view
CREATE VIEW GetClientData AS
    SELECT * FROM Client;
GO

-- Drop existing procedure if it exists
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'CreateClient' AND type = 'P')
    DROP PROCEDURE CreateClient;
GO

-- Create the CreateClient procedure
CREATE PROCEDURE CreateClient
    @CompanyName VARCHAR(64),
    @Address VARCHAR(64),
    @ClientName VARCHAR(64),
    @Title VARCHAR(32),
    @Tier INT,
    @Email VARCHAR(64),
    @Phone VARCHAR(64),
    @DateRenewal DATE,
    @Cost MONEY
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Client WHERE ClientName = @ClientName)
    BEGIN
        INSERT INTO Client (CompanyName, Address, ClientName, Title, Tier, Email, Phone, DateRenewal, Cost)
        VALUES (@CompanyName, @Address, @ClientName, @Title, @Tier, @Email, @Phone, @DateRenewal, @Cost);
        PRINT 'Client created successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Client with the same name already exists.';
    END
END;
GO

-- Drop existing procedure if it exists
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'UpdateClient' AND type = 'P')
    DROP PROCEDURE UpdateClient;
GO

-- Create the UpdateClient procedure
CREATE PROCEDURE UpdateClient
    @ClientId INT,
    @CompanyName VARCHAR(64),
    @Address VARCHAR(64),
    @ClientName VARCHAR(64),
    @Title VARCHAR(32),
    @Tier INT,
    @Email VARCHAR(64),
    @Phone VARCHAR(64),
    @DateRenewal DATE,
    @Cost MONEY
AS
BEGIN
    UPDATE Client
    SET CompanyName = @CompanyName,
        Address = @Address,
        ClientName = @ClientName,
        Title = @Title,
        Tier = @Tier,
        Email = @Email,
        Phone = @Phone,
        DateRenewal = @DateRenewal,
        Cost = @Cost
    WHERE ClientId = @ClientId;
    PRINT 'Client updated successfully.';
END;
GO

-- Drop existing procedure if it exists
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'DeleteClient' AND type = 'P')
    DROP PROCEDURE DeleteClient;
GO

-- Create the DeleteClient procedure
CREATE PROCEDURE DeleteClient
    @ClientId INT
AS
BEGIN
    DELETE FROM Client WHERE ClientId = @ClientId;
    PRINT 'Client deleted successfully.';
END;
GO

PRINT 'Setup script executed successfully.';