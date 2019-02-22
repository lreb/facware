SELECT * FROM sys.schemas;
SELECT * FROM INFORMATION_SCHEMA.TABLES order by TABLE_NAME ;
SELECT * FROM sys.schemas;

IF NOT EXISTS (
SELECT  schema_name
FROM    information_schema.schemata
WHERE   schema_name = 'productionplan' )

USE JabilMaster2;
GO


CREATE SCHEMA productionplan AUTHORIZATION [jabil\chisqladmin]
  -- EXEC sp_addrolemember
GO

-- drop table JabilMaster2.productionplan.Customer;
select * from productionplan.customers;
CREATE TABLE [productionplan].[Customers] (
    [Id]			BIGINT       IDENTITY (1, 1) NOT NULL,
    [Name]			VARCHAR (100) NOT NULL,
	[Enabled]		BIT			DEFAULT 1, 
	[UpdatedDate]	DATETIME      Default GETDATE(),
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC),
);
GO

CREATE TABLE [productionplan].[Users] (
    [Id]			BIGINT       IDENTITY (1, 1) NOT NULL,
	[EmployeeId]	VARCHAR (100) NOT NULL,
    [Name]			VARCHAR (100),
	[LastName]		VARCHAR (100),
	[Email]			VARCHAR (100),
	[Enabled]		BIT			DEFAULT 1, 
	[UpdatedDate]	DATETIME      Default GETDATE(),
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
);
GO

CREATE TABLE [productionplan].[Areas] (
    [Id]			BIGINT        IDENTITY (1, 1) NOT NULL,
	[CustomerId]	BIGINT NOT NULL,
    [UserId]		BIGINT NOT NULL,
    [Name]			VARCHAR (20)  NOT NULL,
    [Type]			VARCHAR (20),
    [Description]	VARCHAR (100),
    [Enabled]		BIT			DEFAULT 1, 
    [UpdateDate]	DATETIME      Default GETDATE(),
    CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Areas_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [productionplan].[Customers] (Id),
    CONSTRAINT [FK_Areas_Users] FOREIGN KEY ([UserId]) REFERENCES [productionplan].[Users] ([Id])
);
GO

CREATE TABLE [productionplan].[AreasProperties] (
    [Id]       BIGINT        IDENTITY (1, 1) NOT NULL,
	[AreaId]     BIGINT NOT NULL,
    [UserId]     BIGINT NOT NULL,
	[Group]     VARCHAR (20)  NOT NULL,
    [Parameter]     VARCHAR (20)  NOT NULL,
    [Value]         VARCHAR (20)  NOT NULL,
    [Enabled]		BIT			DEFAULT 1, 
    [UpdateDate]	DATETIME      Default GETDATE(),
    CONSTRAINT [PK_AreasProperties] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AreasProperties_Areas] FOREIGN KEY ([AreaId]) REFERENCES [productionplan].[Areas] (Id),
    CONSTRAINT [FK_AreasProperties_Users] FOREIGN KEY ([UserId]) REFERENCES [productionplan].[Users] ([Id])
);
GO

CREATE TABLE [productionplan].[Shifts] (
    [Id]			BIGINT        IDENTITY (1, 1) NOT NULL,
	[CustomerId]	BIGINT NOT NULL,
    [Name]			VARCHAR (30)  NOT NULL,
	[StartTime]		TIME NOT NULL,
	[EndTime]		TIME NOT NULL,
    [Enabled]		BIT			DEFAULT 1, 
    [UpdateDate]	DATETIME      Default GETDATE(),
    CONSTRAINT [PK_Shifts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Shifts_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [productionplan].[Customers] (Id),
);
GO

CREATE TABLE [productionplan].[ProductionPlans] (
    [Id]			BIGINT        IDENTITY (1, 1) NOT NULL,
	[ParentId]		BIGINT,
	[OriginalParentId]	BIGINT,
	[CustomerId]	BIGINT NOT NULL,
	[AreaId]		BIGINT NOT NULL,
	[ShiftId]		BIGINT NOT NULL,
    [Name]			VARCHAR (30)  NOT NULL,
	[Revision]		VARCHAR (30)  NOT NULL,
	[StartDate]		DATE NOT NULL,
	[EndDate]		DATE NOT NULL,
    [Enabled]		BIT			DEFAULT 1, 
	[CreateUserId]	BIGINT NOT NULL,
	[CreateDate]	DATETIME      Default GETDATE(),
	[UpdateUserId]	BIGINT,
    [UpdateDate]	DATETIME,
    CONSTRAINT [PK_ProductionPlans] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductionPlans_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [productionplan].[Customers] (Id),
	CONSTRAINT [FK_ProductionPlans_Areas] FOREIGN KEY ([AreaId]) REFERENCES [productionplan].[Areas] (Id),
	CONSTRAINT [FK_ProductionPlans_Shifts] FOREIGN KEY ([ShiftId]) REFERENCES [productionplan].[Shifts] (Id),
);
GO

CREATE TABLE [productionplan].[ProductionPlansDetails] (
    [Id]			BIGINT        IDENTITY (1, 1) NOT NULL,
	[ProductionPlanId]		BIGINT NOT NULL,
	[PlanDate]		DATE NOT NULL,
	[PlannedQuantity]	INT NOT NULL,
    [Enabled]		BIT			DEFAULT 1, 
	[CreateDate]	DATETIME      Default GETDATE(),
    CONSTRAINT [PK_ProductionPlans] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductionPlansDetails_ProductionPlans] FOREIGN KEY ([ProductionPlanId]) REFERENCES [productionplan].[ProductionPlans] (Id),
);
GO

CREATE TABLE [productionplan].[ProductionPlansProperties] (
    [Id]			BIGINT        IDENTITY (1, 1) NOT NULL,
	[ProductionPlanId]		BIGINT NOT NULL,
	[UserId]     BIGINT NOT NULL,
	[Group]     VARCHAR (20)  NOT NULL,
    [Parameter]     VARCHAR (20)  NOT NULL,
    [Value]         VARCHAR (20)  NOT NULL,
    [Enabled]		BIT			DEFAULT 1, 
    [UpdateDate]	DATETIME      Default GETDATE(),
    CONSTRAINT [PK_ProductionPlans] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductionPlansDetails_ProductionPlans] FOREIGN KEY ([ProductionPlanId]) REFERENCES [productionplan].[ProductionPlans] (Id),
	CONSTRAINT [FK_ProductionPlansDetails_Users] FOREIGN KEY ([ProductionPlanId]) REFERENCES [productionplan].[Users] (Id),
);
GO