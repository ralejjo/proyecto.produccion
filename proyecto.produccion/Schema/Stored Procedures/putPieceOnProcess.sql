-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE putPieceOnProcess
	@stationid int,
	@pieceid int
AS
BEGIN
	update Station 
	set 
	pieceIdOnProcess = @pieceid
	where
	id = @stationid
END
GO

