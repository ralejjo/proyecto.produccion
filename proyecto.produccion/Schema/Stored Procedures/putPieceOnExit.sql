-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE putPieceOnExit
	@stationid int,
	@pieceid int
AS
BEGIN
	update Station 
	set 
	pieceIdOnExit = @pieceid
	where
	id = @stationid
END
GO

