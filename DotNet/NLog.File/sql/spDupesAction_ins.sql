SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Pops>
-- Create date: <2020-01-05>
-- Description:	<Insert row into DupesAction table>
-- =============================================
use pops;

DROP PROCEDURE IF EXISTS dbo.spDupesAction_ins;
go

CREATE PROCEDURE dbo.spDupesAction_ins 
	-- Add the parameters for the stored procedure here
	@TheFileName			varchar(100),
	@Folder					varchar(200),
	@SHA					varchar(200),
	@FileExt				varchar(10),
	@FileSize				int,
	@FileCreateDt			smalldatetime,
	@OneDriveRemoved		char(1),
	@GooglePhotosRemoved	char(1)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert DupesAction(	TheFileName,
						Folder,
						SHA,
						FileExt,
						FileSize,
						FileCreateDt,
						OneDriveRemoved,
						GooglePhotosRemoved)
				values (@TheFileName,
						@Folder,
						@SHA,
						@FileExt,
						@FileSize,
						@FileCreateDt,
						@OneDriveRemoved,
						@GooglePhotosRemoved)


END
GO
