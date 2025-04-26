CREATE TABLE [dbo].[Color] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    [isActive]    BIT           CONSTRAINT [DF_Color_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]   DATETIME      CONSTRAINT [DF_Color_startedAt] DEFAULT (getdate()) NOT NULL,
    [udatedAt]    DATETIME      CONSTRAINT [DF_Color_udatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO