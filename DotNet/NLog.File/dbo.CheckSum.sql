CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL identity PRIMARY KEY, 
    [SHA] VARCHAR(200) NOT NULL, 
    [Folder] VARCHAR(200) NOT NULL, 
    [FileName] VARCHAR(100) NOT NULL, 
    [Notes] VARCHAR(200) NULL
)
