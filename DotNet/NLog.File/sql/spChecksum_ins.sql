-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Pops>
-- Create date: <2019-12-21>
-- Description:	<Insert row into CheckSum table>
-- =============================================

DROP PROCEDURE IF EXISTS dbo.spCheckSum_ins;
go

CREATE PROCEDURE dbo.spCheckSum_ins 
	-- Add the parameters for the stored procedure here
	@SHA			varchar(200),
	@Folder			varchar(200),
	@TheFileName	varchar(100),
	@FileSize		int,
	@Notes			varchar(200)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert CheckSum(	SHA,
						Folder,
						TheFileName,
						FileSize,
						Notes)
				values (@SHA,
						@Folder,
						@TheFileName,
						@FileSize,
						@Notes)


END
GO
