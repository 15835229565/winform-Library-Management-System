using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书馆管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }


        /*该应用使用的是本地数据库，需要先用以下语句，在MySQL中创建数据库和表

                create database 图书馆管理系统
        use 图书馆管理系统
        create table 管理员信息表
        (
        id int identity(0,1) primary key,
        username nvarchar(15),
        pwd varchar(20),
        权限 nvarchar(10)
        )

        create table 图书信息表
        (
        id int identity(0,1) primary key,
        编号 nvarchar(20),
        书名 nvarchar(20),
        作者 nvarchar(20),
        出版社 nvarchar(20),
        价格 decimal (20,0),
        来源 nvarchar(20),
        是否借出 nvarchar(10),
        种类 nvarchar(20),
        入库时间 date,
        备注 nvarchar(20)
        )
        create table 借阅表
        (
        id int identity(0,1) primary key,
        身份证号 nvarchar(30),
        编号 nvarchar(20),
        姓名 nvarchar(20),
        性别 nvarchar(10),
        借阅日期 date,
        应还日期 date,
        备注 nvarchar(20)
        )
        create table 账号记录
        (
        id int identity(0,1) primary key,
        username varchar(20),
        pwd varchar(30)
        )
        */






    }
}
