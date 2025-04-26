CREATE TABLE [dbo].[ProcessType] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    [isActive]    BIT           CONSTRAINT [DF_ProcessType_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]   DATETIME      CONSTRAINT [DF_ProcessType_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]   DATETIME      CONSTRAINT [DF_ProcessType_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ProcessType] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

