-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsWorkOrder]
	@date date,
	@lote int = null,
	@colada int = null,
	@clientid int,
	@pieceid int,
	@quantity int,
	@processtypeid int
AS
BEGIN
	insert into WorkOrder (date,lote,colada,clientId,pieceId,quantity,processTypeId)
	values
	(@date,@lote,@colada,@clientid,@pieceid,@quantity,@processtypeid)
END
GO

