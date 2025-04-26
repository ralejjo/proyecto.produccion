-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE putPieceOnEntry
	@stationid int,
	@pieceid int
AS
BEGIN
	update Station 
	set 
	pieceIdOnEntry = @pieceid
	where
	id = @stationid
END
GO

