

USE Backend_ApiNetCore3_1
go



alter table dbo.AppUser set (SYSTEM_VERSIONING = off)
drop table dbo.AppUserHistory
drop table dbo.AppUser

alter table dbo.Employee set (SYSTEM_VERSIONING = off)
drop table dbo.EmployeeHistory
drop table dbo.Employee

alter table dbo.Position set (SYSTEM_VERSIONING = off)
drop table dbo.PositionHistory
drop table dbo.Position



CREATE TABLE dbo.AppUser(
    UserId            int             IDENTITY(1,1),
    BusinessUnitId    int             NOT NULL,
    UserEmail         char(70)        NOT NULL,
    UserName          varchar(200)    NULL,
    [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START,
    [ValidTo] datetime2 GENERATED ALWAYS AS ROW END,
    CONSTRAINT PK_AppUser PRIMARY KEY CLUSTERED (UserId),
	PERIOD FOR SYSTEM_TIME(ValidFrom, ValidTo)
)
WITH(SYSTEM_VERSIONING = ON(HISTORY_TABLE = dbo.AppUserHistory))
go



CREATE TABLE dbo.Position(
    PositionId      int            IDENTITY(1,1),
    PositionName    varchar(50)    NOT NULL,
    PositionCode    char(10)       NOT NULL,
    InsertDate      datetime       NOT NULL,
    UpdateDate      datetime       NULL,
    UpdaterUserId   int            NOT NULL,
    
	[ValidFrom] datetime2 GENERATED ALWAYS AS ROW START,
    [ValidTo] datetime2 GENERATED ALWAYS AS ROW END,
    CONSTRAINT PK_Positions PRIMARY KEY CLUSTERED (PositionId) ,
	PERIOD FOR SYSTEM_TIME(ValidFrom, ValidTo)
)
WITH(SYSTEM_VERSIONING = ON(HISTORY_TABLE = dbo.PositionHistory))
go


CREATE TABLE dbo.Employee(
    EmployeeId                 int               IDENTITY(1,1),
    PositionId                 int               NOT NULL,
    EmployeeName               varchar(200)      NULL,
    GenderCode                 char(1)           NULL
                               CHECK (GenderCode in ('M', 'F')),
    HiringDate                 date              NULL,
    DependentsQuantity         char(10)          NULL,
    SalaryValue                varchar(256)    NULL,
    InsertDate				   datetime          NOT NULL,
    UpdateDate                 datetime          NULL,
    UpdaterUserId              int               NOT NULL,
	[ValidFrom] datetime2 GENERATED ALWAYS AS ROW START,
    [ValidTo] datetime2 GENERATED ALWAYS AS ROW END,
    CONSTRAINT PK_Employee PRIMARY KEY CLUSTERED (EmployeeId),
	PERIOD FOR SYSTEM_TIME(ValidFrom, ValidTo)
)
WITH(SYSTEM_VERSIONING = ON(HISTORY_TABLE = dbo.EmployeeHistory))
go



CREATE INDEX ie01_AppUser ON dbo.AppUser(UserEmail)
go

ALTER TABLE dbo.Employee ADD CONSTRAINT RefPositions47 
    FOREIGN KEY (PositionId)
    REFERENCES dbo.Position(PositionId)
go

ALTER TABLE dbo.Employee ADD CONSTRAINT RefAppUser99 
    FOREIGN KEY (UpdaterUserId)
    REFERENCES dbo.AppUser(UserId)
go

ALTER TABLE dbo.Position ADD CONSTRAINT RefAppUser103 
    FOREIGN KEY (UpdaterUserId)
    REFERENCES dbo.AppUser(UserId)
go

