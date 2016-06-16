
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/16/2016 10:42:43
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
IF OBJECT_ID(N'[dbo].[FK_GUARDSITESITEMANAGER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SITEMANAGERS] DROP CONSTRAINT [FK_GUARDSITESITEMANAGER];
GO
IF OBJECT_ID(N'[dbo].[FK_SITEMANAGERCONTACTINFO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CONTACTINFOS] DROP CONSTRAINT [FK_SITEMANAGERCONTACTINFO];
GO
IF OBJECT_ID(N'[dbo].[FK_GUARDSITEADDRESS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ADDRESSES] DROP CONSTRAINT [FK_GUARDSITEADDRESS];
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
IF OBJECT_ID(N'[dbo].[GUARDSITES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GUARDSITES];
GO
IF OBJECT_ID(N'[dbo].[SITEMANAGERS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SITEMANAGERS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EMPLOYEES'
CREATE TABLE [dbo].[EMPLOYEES] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [RCODE] nvarchar(max)  NOT NULL,
    [LASTNAME] nvarchar(max)  NOT NULL,
    [FIRSTNAME] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ADDRESSES'
CREATE TABLE [dbo].[ADDRESSES] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [CITY] nvarchar(max)  NULL,
    [STREET] nvarchar(max)  NULL,
    [STATE] nvarchar(max)  NULL,
    [POSTALCODE] nvarchar(max)  NULL,
    [EMPLOYEE_RGUID] uniqueidentifier  NULL,
    [GUARDSITE_RGUID] uniqueidentifier  NULL
);
GO

-- Creating table 'CONTACTINFOS'
CREATE TABLE [dbo].[CONTACTINFOS] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [PHONE1] nvarchar(max)  NULL,
    [PHONE2] nvarchar(max)  NULL,
    [EMAIL] nvarchar(max)  NULL,
    [EMPLOYEE_RGUID] uniqueidentifier  NULL,
    [SITEMANAGER_RGUID] uniqueidentifier  NULL
);
GO

-- Creating table 'EMPLOYEEDETAILS'
CREATE TABLE [dbo].[EMPLOYEEDETAILS] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [AT] nvarchar(max)  NULL,
    [AFM] nvarchar(max)  NULL,
    [GENDER] int  NULL,
    [BIRTHDATE] datetime  NULL,
    [MARITALSTATUS] int  NULL,
    [SECLICEXPDATE] datetime  NULL,
    [EMPLOYEE_RGUID] uniqueidentifier  NULL
);
GO

-- Creating table 'GUARDSITES'
CREATE TABLE [dbo].[GUARDSITES] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [RCODE] nvarchar(max)  NOT NULL,
    [SITENAME] nvarchar(max)  NOT NULL,
    [ISACTIVE] int  NOT NULL
);
GO

-- Creating table 'SITEMANAGERS'
CREATE TABLE [dbo].[SITEMANAGERS] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [NAME] nvarchar(max)  NOT NULL,
    [GUARDSITE_RGUID] uniqueidentifier  NULL
);
GO

-- Creating table 'SHIFTS'
CREATE TABLE [dbo].[SHIFTS] (
    [RGUID] uniqueidentifier  NOT NULL default newsequentialid(),
    [FROM] datetime  NOT NULL,
    [TO] datetime  NOT NULL,
    [EMPLOYEERGUID] uniqueidentifier  NOT NULL,
    [GUARDSITERGUID] uniqueidentifier  NOT NULL
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

-- Creating primary key on [RGUID] in table 'GUARDSITES'
ALTER TABLE [dbo].[GUARDSITES]
ADD CONSTRAINT [PK_GUARDSITES]
    PRIMARY KEY CLUSTERED ([RGUID] ASC);
GO

-- Creating primary key on [RGUID] in table 'SITEMANAGERS'
ALTER TABLE [dbo].[SITEMANAGERS]
ADD CONSTRAINT [PK_SITEMANAGERS]
    PRIMARY KEY CLUSTERED ([RGUID] ASC);
GO

-- Creating primary key on [RGUID] in table 'SHIFTS'
ALTER TABLE [dbo].[SHIFTS]
ADD CONSTRAINT [PK_SHIFTS]
    PRIMARY KEY CLUSTERED ([RGUID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EMPLOYEE_RGUID] in table 'ADDRESSES'
ALTER TABLE [dbo].[ADDRESSES]
ADD CONSTRAINT [FK_EMPLOYEEADDRESS]
    FOREIGN KEY ([EMPLOYEE_RGUID])
    REFERENCES [dbo].[EMPLOYEES]
        ([RGUID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EMPLOYEEADDRESS'
CREATE INDEX [IX_FK_EMPLOYEEADDRESS]
ON [dbo].[ADDRESSES]
    ([EMPLOYEE_RGUID]);
GO

-- Creating foreign key on [EMPLOYEE_RGUID] in table 'CONTACTINFOS'
ALTER TABLE [dbo].[CONTACTINFOS]
ADD CONSTRAINT [FK_EMPLOYEECONTACTINFO]
    FOREIGN KEY ([EMPLOYEE_RGUID])
    REFERENCES [dbo].[EMPLOYEES]
        ([RGUID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EMPLOYEECONTACTINFO'
CREATE INDEX [IX_FK_EMPLOYEECONTACTINFO]
ON [dbo].[CONTACTINFOS]
    ([EMPLOYEE_RGUID]);
GO

-- Creating foreign key on [EMPLOYEE_RGUID] in table 'EMPLOYEEDETAILS'
ALTER TABLE [dbo].[EMPLOYEEDETAILS]
ADD CONSTRAINT [FK_EMPLOYEEEMPLOYEEDETAIL]
    FOREIGN KEY ([EMPLOYEE_RGUID])
    REFERENCES [dbo].[EMPLOYEES]
        ([RGUID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EMPLOYEEEMPLOYEEDETAIL'
CREATE INDEX [IX_FK_EMPLOYEEEMPLOYEEDETAIL]
ON [dbo].[EMPLOYEEDETAILS]
    ([EMPLOYEE_RGUID]);
GO

-- Creating foreign key on [GUARDSITE_RGUID] in table 'SITEMANAGERS'
ALTER TABLE [dbo].[SITEMANAGERS]
ADD CONSTRAINT [FK_GUARDSITESITEMANAGER]
    FOREIGN KEY ([GUARDSITE_RGUID])
    REFERENCES [dbo].[GUARDSITES]
        ([RGUID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GUARDSITESITEMANAGER'
CREATE INDEX [IX_FK_GUARDSITESITEMANAGER]
ON [dbo].[SITEMANAGERS]
    ([GUARDSITE_RGUID]);
GO

-- Creating foreign key on [SITEMANAGER_RGUID] in table 'CONTACTINFOS'
ALTER TABLE [dbo].[CONTACTINFOS]
ADD CONSTRAINT [FK_SITEMANAGERCONTACTINFO]
    FOREIGN KEY ([SITEMANAGER_RGUID])
    REFERENCES [dbo].[SITEMANAGERS]
        ([RGUID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SITEMANAGERCONTACTINFO'
CREATE INDEX [IX_FK_SITEMANAGERCONTACTINFO]
ON [dbo].[CONTACTINFOS]
    ([SITEMANAGER_RGUID]);
GO

-- Creating foreign key on [GUARDSITE_RGUID] in table 'ADDRESSES'
ALTER TABLE [dbo].[ADDRESSES]
ADD CONSTRAINT [FK_GUARDSITEADDRESS]
    FOREIGN KEY ([GUARDSITE_RGUID])
    REFERENCES [dbo].[GUARDSITES]
        ([RGUID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GUARDSITEADDRESS'
CREATE INDEX [IX_FK_GUARDSITEADDRESS]
ON [dbo].[ADDRESSES]
    ([GUARDSITE_RGUID]);
GO

-- Creating foreign key on [EMPLOYEERGUID] in table 'SHIFTS'
ALTER TABLE [dbo].[SHIFTS]
ADD CONSTRAINT [FK_EMPLOYEESHIFT]
    FOREIGN KEY ([EMPLOYEERGUID])
    REFERENCES [dbo].[EMPLOYEES]
        ([RGUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EMPLOYEESHIFT'
CREATE INDEX [IX_FK_EMPLOYEESHIFT]
ON [dbo].[SHIFTS]
    ([EMPLOYEERGUID]);
GO

-- Creating foreign key on [GUARDSITERGUID] in table 'SHIFTS'
ALTER TABLE [dbo].[SHIFTS]
ADD CONSTRAINT [FK_GUARDSITESHIFT]
    FOREIGN KEY ([GUARDSITERGUID])
    REFERENCES [dbo].[GUARDSITES]
        ([RGUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GUARDSITESHIFT'
CREATE INDEX [IX_FK_GUARDSITESHIFT]
ON [dbo].[SHIFTS]
    ([GUARDSITERGUID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------