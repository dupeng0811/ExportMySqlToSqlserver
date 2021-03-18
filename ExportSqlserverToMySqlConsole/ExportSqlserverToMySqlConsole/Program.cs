using System;
using System.Collections.Generic;
using ExportSqlserverToMySqlConsole.BookSharings;
using ReadBook.ManagementPlatform;
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
                ConnectionString = "Data Source=ebooklist_mobi.db;Cache=Shared;",
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true
            });


            //List<Books> booksList = sqlserverSugarClient.Queryable<Books>().ToList();
            //foreach (Books books in booksList)
            //{
            //    books.Introduction = null;
            //    Console.WriteLine(books.Name);
            //    mySqlSugarClient.Insertable<Books>(books).ExecuteCommand();
            //}

            //List<BookResources> bookResourcesList = sqlserverSugarClient.Queryable<BookResources>().ToList();
            //foreach (BookResources resources in bookResourcesList)
            //{
            //    resources.PhysicalPath = null;
            //    Console.WriteLine(resources.FileName +" BookId="+resources.BookId);
            //    mySqlSugarClient.Insertable<BookResources>(resources).ExecuteCommand();
            //}

            List<autokeywordreply> autokeywordreplies = sqlserverSugarClient.Ado.SqlQuery<autokeywordreply>("select  w.KeyWord,t.Text from WeiChat_KeyWordAutoReply w inner join WeiChat_KeyWordTextContent t on w.ContentId = t.Id");
            foreach (autokeywordreply item in autokeywordreplies)
            {
                Console.WriteLine(item.Keyword);
                WechatKeyWordAutoReply wechatKeyWordAutoReply = new WechatKeyWordAutoReply()
                {
                    KeyWord = item.Keyword,
                    MatchType = WechatAutoReplyKeywordMatchType.Equals,
                    AllowEventKeyTrigger = true,
                    TenantId =1,
                    CreationTime = DateTime.Now
                }  ;


               int keywordId = mySqlSugarClient.Insertable<WechatKeyWordAutoReply>(wechatKeyWordAutoReply)
                    .ExecuteReturnIdentity();
                WechatKeyWordAutoReplyItem replyItem = new WechatKeyWordAutoReplyItem()
                { 
                    KeyWordContentType = WechatAutoReplyKeyWordContentType.Text,
                    TextContent = item.Text,
                    WechatKeyWordAutoReplyId = keywordId,
                    CreationTime = DateTime.Now,
                    TenantId = 1
                    };
                mySqlSugarClient.Insertable(replyItem).ExecuteCommand();
            }
        }
    }

    public class autokeywordreply
    {
        public string Keyword { get; set; }
        public string Text { get; set; }
    }
}
