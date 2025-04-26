CREATE TABLE [dbo].[Piece] (
    [id]           INT        IDENTITY (1, 1) NOT NULL,
    [colorId]      INT        NOT NULL,
    [materialId]   INT        NOT NULL,
    [stateId]      INT        NOT NULL,
    [typeId]       INT        NOT NULL,
    [width]        FLOAT (53) NOT NULL,
    [length]       FLOAT (53) NOT NULL,
    [thickness]    FLOAT (53) NOT NULL,
    [pieceOrderId] INT        NOT NULL,
    [isActive]     BIT        CONSTRAINT [DF_Piece_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]    DATETIME   CONSTRAINT [DF_Piece_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]    DATETIME   CONSTRAINT [DF_Piece_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Piece] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Piece_Color] FOREIGN KEY ([colorId]) REFERENCES [dbo].[Color] ([id]),
    CONSTRAINT [FK_Piece_Material] FOREIGN KEY ([materialId]) REFERENCES [dbo].[Material] ([id]),
    CONSTRAINT [FK_Piece_Piece] FOREIGN KEY ([pieceOrderId]) REFERENCES [dbo].[Piece] ([id]),
    CONSTRAINT [FK_Piece_PieceType] FOREIGN KEY ([typeId]) REFERENCES [dbo].[PieceType] ([id]),
    CONSTRAINT [FK_Piece_State] FOREIGN KEY ([stateId]) REFERENCES [dbo].[State] ([id])
);
GO

