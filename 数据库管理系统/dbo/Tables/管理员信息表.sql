CREATE TABLE [dbo].[管理员信息表] (
    [id]       INT           IDENTITY (0, 1) NOT NULL,
    [username] NVARCHAR (15) NULL,
    [pwd]      VARCHAR (20)  NULL,
    [权限]       NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

