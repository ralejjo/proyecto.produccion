CREATE TABLE [dbo].[StationType] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    [isActive]    BIT           CONSTRAINT [DF_StationType_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]   DATETIME      CONSTRAINT [DF_StationType_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]   DATETIME      CONSTRAINT [DF_StationType_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_StationType] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

