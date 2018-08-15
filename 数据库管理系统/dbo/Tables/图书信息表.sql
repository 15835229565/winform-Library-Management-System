CREATE TABLE [dbo].[图书信息表] (
    [id]   INT           IDENTITY (0, 1) NOT NULL,
    [编号]   NVARCHAR (20) NULL,
    [书名]   NVARCHAR (20) NULL,
    [作者]   NVARCHAR (20) NULL,
    [出版社]  NVARCHAR (20) NULL,
    [价格]   DECIMAL (20)  NULL,
    [来源]   NVARCHAR (20) NULL,
    [是否借出] NVARCHAR (10) NULL,
    [种类]   NVARCHAR (20) NULL,
    [入库时间] DATE          NULL,
    [备注]   NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

