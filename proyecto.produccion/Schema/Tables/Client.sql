CREATE TABLE [dbo].[Client] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50) NOT NULL,
    [address]     NVARCHAR (50) NOT NULL,
    [mobilephone] NVARCHAR (50) NOT NULL,
    [cuit]        INT           NOT NULL,
    [isActive]    BIT           CONSTRAINT [DF_Client_isActive] DEFAULT ((1)) NOT NULL,
    [startedAt]   DATETIME      CONSTRAINT [DF_Client_startedAt] DEFAULT (getdate()) NOT NULL,
    [updatedAt]   DATETIME      CONSTRAINT [DF_Client_updatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO