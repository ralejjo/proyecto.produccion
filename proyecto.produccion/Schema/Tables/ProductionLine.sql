CREATE TABLE [dbo].[ProductionLine] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    [isActive]    BIT           CONSTRAINT [DF_ProductionLine_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]   DATETIME      CONSTRAINT [DF_ProductionLine_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]   DATETIME      CONSTRAINT [DF_ProductionLine_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ProductionLine] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

