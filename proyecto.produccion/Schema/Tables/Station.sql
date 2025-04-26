CREATE TABLE [dbo].[Station] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (50) NOT NULL,
    [pieceIdOnEntry]   INT           NULL,
    [pieceIdOnProcess] INT           NULL,
    [pieceIdOnExit]    INT           NULL,
    [stationTypeId]    INT           NOT NULL,
    [productionLineId] INT           NOT NULL,
    [isActive]         BIT           CONSTRAINT [DF_Station_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]        DATETIME      CONSTRAINT [DF_Station_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]        DATETIME      CONSTRAINT [DF_Station_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Station] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Station_Piece] FOREIGN KEY ([pieceIdOnEntry]) REFERENCES [dbo].[Piece] ([id]),
    CONSTRAINT [FK_Station_Piece1] FOREIGN KEY ([pieceIdOnExit]) REFERENCES [dbo].[Piece] ([id]),
    CONSTRAINT [FK_Station_Piece2] FOREIGN KEY ([pieceIdOnProcess]) REFERENCES [dbo].[Piece] ([id]),
    CONSTRAINT [FK_Station_ProductionLine] FOREIGN KEY ([productionLineId]) REFERENCES [dbo].[ProductionLine] ([id]),
    CONSTRAINT [FK_Station_StationType] FOREIGN KEY ([stationTypeId]) REFERENCES [dbo].[StationType] ([id])
);
GO

