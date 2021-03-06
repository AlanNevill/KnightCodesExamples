/*
   09 January 202012:32:20
   User: 
   Server: (localdb)\ProjectsV13
   Database: pops
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CheckSum
	DROP CONSTRAINT DF__CheckSum__FileSi__239E4DCF
GO
ALTER TABLE dbo.CheckSum
	DROP CONSTRAINT DF__CheckSum__FileCr__24927208
GO
ALTER TABLE dbo.CheckSum
	DROP CONSTRAINT DF__CheckSum__TimerM__25869641
GO
CREATE TABLE dbo.Tmp_CheckSum
	(
	Id int NOT NULL IDENTITY (1, 1),
	SHA varchar(200) NOT NULL,
	Folder varchar(200) NOT NULL,
	TheFileName varchar(200) NOT NULL,
	FileExt varchar(10) NOT NULL,
	FileSize int NOT NULL,
	FileCreateDt smalldatetime NOT NULL,
	TimerMs int NOT NULL,
	Notes varchar(200) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_CheckSum SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_CheckSum ADD CONSTRAINT
	DF__CheckSum__FileSi__239E4DCF DEFAULT ((0)) FOR FileSize
GO
ALTER TABLE dbo.Tmp_CheckSum ADD CONSTRAINT
	DF__CheckSum__FileCr__24927208 DEFAULT ('1900-01-01') FOR FileCreateDt
GO
ALTER TABLE dbo.Tmp_CheckSum ADD CONSTRAINT
	DF__CheckSum__TimerM__25869641 DEFAULT ((0)) FOR TimerMs
GO
SET IDENTITY_INSERT dbo.Tmp_CheckSum ON
GO
IF EXISTS(SELECT * FROM dbo.CheckSum)
	 EXEC('INSERT INTO dbo.Tmp_CheckSum (Id, SHA, Folder, TheFileName, FileExt, FileSize, FileCreateDt, TimerMs, Notes)
		SELECT Id, SHA, Folder, TheFileName, FileExt, FileSize, FileCreateDt, TimerMs, Notes FROM dbo.CheckSum WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_CheckSum OFF
GO
DROP TABLE dbo.CheckSum
GO
EXECUTE sp_rename N'dbo.Tmp_CheckSum', N'CheckSum', 'OBJECT' 
GO
ALTER TABLE dbo.CheckSum ADD CONSTRAINT
	PK__CheckSum__3214EC07755FAA5C PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
