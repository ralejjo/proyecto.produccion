CREATE TABLE [dbo].[WorkOrder] (
    [id]            INT      IDENTITY (1, 1) NOT NULL,
    [date]          DATE     NOT NULL,
    [lote]          INT      NULL,
    [colada]        INT      NULL,
    [clientId]      INT      NOT NULL,
    [pieceId]       INT      NOT NULL,
    [quantity]      INT      NOT NULL,
    [processTypeId] INT      NOT NULL,
    [isActive]      BIT      CONSTRAINT [DF_WorkOrder_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]     DATETIME CONSTRAINT [DF_WorkOrder_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]     DATETIME CONSTRAINT [DF_WorkOrder_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_WorkOrder] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_WorkOrder_Client] FOREIGN KEY ([clientId]) REFERENCES [dbo].[Client] ([id]),
    CONSTRAINT [FK_WorkOrder_Piece] FOREIGN KEY ([pieceId]) REFERENCES [dbo].[Piece] ([id]),
    CONSTRAINT [FK_WorkOrder_ProcessType] FOREIGN KEY ([processTypeId]) REFERENCES [dbo].[ProcessType] ([id])
);
GO

