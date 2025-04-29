-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE InsPiece
	@colorid int,
	@materialid int,
	@stateid int,
	@typeid int,
	@width float,
	@length float,
	@thickness float,
	@pieceorderid int = null
AS
BEGIN
	insert into Piece(colorId,materialId,stateId,typeId,width,length,thickness,pieceOrderId)
	values
	(@colorid,@materialid,@stateid,@typeid,@width,@length,@thickness,@pieceorderid)

	select scope_identity() as [identity]
END
GO

