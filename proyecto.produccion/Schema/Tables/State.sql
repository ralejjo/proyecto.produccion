CREATE TABLE [dbo].[State] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    [isActive]    BIT           CONSTRAINT [DF_State_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]   DATETIME      CONSTRAINT [DF_State_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]   DATETIME      CONSTRAINT [DF_State_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

