CREATE TABLE [dbo].[PieceType] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    [isActive]    BIT           CONSTRAINT [DF_PieceType_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]   DATETIME      CONSTRAINT [DF_PieceType_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]   DATETIME      CONSTRAINT [DF_PieceType_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_PieceType] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

