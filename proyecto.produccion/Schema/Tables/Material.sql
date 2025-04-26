CREATE TABLE [dbo].[Material] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    [isActive]    BIT           CONSTRAINT [DF_Material_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]   DATETIME      CONSTRAINT [DF_Material_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]   DATETIME      CONSTRAINT [DF_Material_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO