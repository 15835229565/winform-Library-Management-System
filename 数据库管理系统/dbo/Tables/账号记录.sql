CREATE TABLE [dbo].[账号记录] (
    [id]       INT          IDENTITY (0, 1) NOT NULL,
    [username] VARCHAR (20) NULL,
    [pwd]      VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

