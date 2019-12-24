-- CheckSumDups.Table.sql

use pops
go

DROP TABLE IF EXISTS [dbo].CheckSumDups;
go

CREATE TABLE [dbo].CheckSumDups
(
	Id			INT				NOT NULL, 
    SHA			VARCHAR(200)	NOT NULL, 
    ToDelete	CHAR(1)			not NULL	default 'N',
	CONSTRAINT PK_CheckSumDups PRIMARY KEY (Id, SHA)
)
