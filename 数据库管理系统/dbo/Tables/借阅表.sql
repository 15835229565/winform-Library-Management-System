CREATE TABLE [dbo].[借阅表] (
    [id]   INT           IDENTITY (0, 1) NOT NULL,
    [身份证号] NVARCHAR (30) NULL,
    [编号]   NVARCHAR (20) NULL,
    [姓名]   NVARCHAR (20) NULL,
    [性别]   NVARCHAR (10) NULL,
    [借阅日期] DATE          NULL,
    [应还日期] DATE          NULL,
    [备注]   NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

