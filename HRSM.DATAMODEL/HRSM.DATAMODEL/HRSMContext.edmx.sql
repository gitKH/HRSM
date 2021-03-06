
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/17/2016 13:37:48
-- Generated from EDMX file: C:\HRSM\HRSM.DATAMODEL\HRSM.DATAMODEL\HRSMContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HRSM];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EMPLOYEEADDRESS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ADDRESSES] DROP CONSTRAINT [FK_EMPLOYEEADDRESS];
GO
IF OBJECT_ID(N'[dbo].[FK_EMPLOYEECONTACTINFO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CONTACTINFOS] DROP CONSTRAINT [FK_EMPLOYEECONTACTINFO];
GO
IF OBJECT_ID(N'[dbo].[FK_EMPLOYEEEMPLOYEEDETAIL]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EMPLOYEEDETAILS] DROP CONSTRAINT [FK_EMPLOYEEEMPLOYEEDETAIL];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EMPLOYEES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EMPLOYEES];
GO
IF OBJECT_ID(N'[dbo].[ADDRESSES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ADDRESSES];
GO
IF OBJECT_ID(N'[dbo].[CONTACTINFOS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CONTACTINFOS];
GO
IF OBJECT_ID(N'[dbo].[EMPLOYEEDETAILS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EMPLOYEEDETAILS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EMPLOYEES'
CREATE TABLE [dbo].[EMPLOYEES] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [RCODE] nvarchar(max)  NOT NULL,
    [LASTNAME] nvarchar(max)  NOT NULL,
    [FIRSTNAME] nvarchar(max)  NOT NULL,
    [ADDRESS_RGUID] uniqueidentifier  NOT NULL,
    [CONTACTINFO_RGUID] uniqueidentifier  NOT NULL,
    [EMPLOYEEDETAIL_RGUID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ADDRESSES'
CREATE TABLE [dbo].[ADDRESSES] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [CITY] nvarchar(max)  NULL,
    [STREET] nvarchar(max)  NULL,
    [STATE] nvarchar(max)  NULL,
    [POSTALCODE] nvarchar(max)  NULL
);
GO

-- Creating table 'CONTACTINFOS'
CREATE TABLE [dbo].[CONTACTINFOS] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [PHONE1] nvarchar(max)  NULL,
    [PHONE2] nvarchar(max)  NULL,
    [EMAIL] nvarchar(max)  NULL
);
GO

-- Creating table 'EMPLOYEEDETAILS'
CREATE TABLE [dbo].[EMPLOYEEDETAILS] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [AT] nvarchar(max)  NULL,
    [AFM] nvarchar(max)  NULL,
    [GENDER] int  NULL,
    [BIRTHDATE] datetime  NULL,
    [MARITALSTATUS] bit  NULL,
    [SECLICEXPDATE] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RGUID] in table 'EMPLOYEES'
ALTER TABLE [dbo].[EMPLOYEES]
ADD CONSTRAINT [PK_EMPLOYEES]
    PRIMARY KEY CLUSTERED ([RGUID] ASC);
GO

-- Creating primary key on [RGUID] in table 'ADDRESSES'
ALTER TABLE [dbo].[ADDRESSES]
ADD CONSTRAINT [PK_ADDRESSES]
    PRIMARY KEY CLUSTERED ([RGUID] ASC);
GO

-- Creating primary key on [RGUID] in table 'CONTACTINFOS'
ALTER TABLE [dbo].[CONTACTINFOS]
ADD CONSTRAINT [PK_CONTACTINFOS]
    PRIMARY KEY CLUSTERED ([RGUID] ASC);
GO

-- Creating primary key on [RGUID] in table 'EMPLOYEEDETAILS'
ALTER TABLE [dbo].[EMPLOYEEDETAILS]
ADD CONSTRAINT [PK_EMPLOYEEDETAILS]
    PRIMARY KEY CLUSTERED ([RGUID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ADDRESS_RGUID] in table 'EMPLOYEES'
ALTER TABLE [dbo].[EMPLOYEES]
ADD CONSTRAINT [FK_EMPLOYEEADDRESS]
    FOREIGN KEY ([ADDRESS_RGUID])
    REFERENCES [dbo].[ADDRESSES]
        ([RGUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EMPLOYEEADDRESS'
CREATE INDEX [IX_FK_EMPLOYEEADDRESS]
ON [dbo].[EMPLOYEES]
    ([ADDRESS_RGUID]);
GO

-- Creating foreign key on [CONTACTINFO_RGUID] in table 'EMPLOYEES'
ALTER TABLE [dbo].[EMPLOYEES]
ADD CONSTRAINT [FK_EMPLOYEECONTACTINFO]
    FOREIGN KEY ([CONTACTINFO_RGUID])
    REFERENCES [dbo].[CONTACTINFOS]
        ([RGUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EMPLOYEECONTACTINFO'
CREATE INDEX [IX_FK_EMPLOYEECONTACTINFO]
ON [dbo].[EMPLOYEES]
    ([CONTACTINFO_RGUID]);
GO

-- Creating foreign key on [EMPLOYEEDETAIL_RGUID] in table 'EMPLOYEES'
ALTER TABLE [dbo].[EMPLOYEES]
ADD CONSTRAINT [FK_EMPLOYEEEMPLOYEEDETAIL]
    FOREIGN KEY ([EMPLOYEEDETAIL_RGUID])
    REFERENCES [dbo].[EMPLOYEEDETAILS]
        ([RGUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EMPLOYEEEMPLOYEEDETAIL'
CREATE INDEX [IX_FK_EMPLOYEEEMPLOYEEDETAIL]
ON [dbo].[EMPLOYEES]
    ([EMPLOYEEDETAIL_RGUID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------