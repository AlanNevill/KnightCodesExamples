-- DupesAction.Table.sql

DROP TABLE IF EXISTS [dbo].DupesAction;
go

CREATE TABLE [dbo].DupesAction
(
    TheFileName			VARCHAR(100)	NOT NULL	primary key,
    Folder				VARCHAR(200)	NOT NULL, 
    SHA					VARCHAR(200)	NOT NULL, 
	FileExt				varchar(10)		not null,
	FileSize			int				not null	default 0,
	FileCreateDt		smalldatetime	not null	default '1900-01-01',
	OneDriveRemoved		char(1)			not null	default 'N',
	GooglePhotosRemoved	char(1)			not null	default 'N'
)
