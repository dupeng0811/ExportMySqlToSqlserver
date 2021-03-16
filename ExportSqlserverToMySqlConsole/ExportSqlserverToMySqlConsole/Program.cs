using System;
using System.Collections.Generic;
using ExportSqlserverToMySqlConsole.BookSharings;
using SqlSugar;

namespace ExportSqlserverToMySqlConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建数据库对象
            SqlSugarClient sqlserverSugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=192.168.1.103;Initial Catalog=DhoopuX.BookSharing;UID=sa;pwd=M4jiE9J8OMUt;",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });   
            
            SqlSugarClient mySqlSugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=localhost;port=3307;uid=ebooklist_mobi;pwd=aGcR91wKJZeum21i;database=ebooklist_mobi",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });


            /*List<Books> booksList = sqlserverSugarClient.Queryable<Books>().ToList();
            foreach (Books books in booksList)
            {
                Console.WriteLine(books.Name);
                mySqlSugarClient.Insertable<Books>(books).ExecuteCommand();
            }*/

            List<BookResources> bookResourcesList = sqlserverSugarClient.Queryable<BookResources>().ToList();
            foreach (BookResources resources in bookResourcesList)
            {
                Console.WriteLine(resources.FileName +" BookId="+resources.BookId);
                mySqlSugarClient.Insertable<BookResources>(resources).ExecuteCommand();
            }
        }
    }
}
