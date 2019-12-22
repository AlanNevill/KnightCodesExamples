-- CheckSum.Table.sql

DROP TABLE IF EXISTS [dbo].CheckSum;
go

CREATE TABLE [dbo].CheckSum
(
	[Id]			INT				NOT NULL identity PRIMARY KEY, 
    [SHA]			VARCHAR(200)	NOT NULL, 
    [Folder]		VARCHAR(200)	NOT NULL, 
    [TheFileName]	VARCHAR(100)	NOT NULL,
	FileExt			varchar(10)		not null,
	FileSize		int				not null	default 0,
	FileCreateDt	smalldatetime	not null	default '1900-01-01',
	TimerMs			int				not null	default 0,
    [Notes]			VARCHAR(200)	NULL
)
