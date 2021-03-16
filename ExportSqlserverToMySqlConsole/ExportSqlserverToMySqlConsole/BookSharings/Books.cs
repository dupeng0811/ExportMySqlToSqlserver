using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace ExportSqlserverToMySqlConsole.BookSharings
{
    public class Books
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [StringLength(500)]
        public string CoverPicture { get; set; }

        public string Category { get; set; }

        public string Introduction { get; set; }

        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }
        [StringLength(500)]
        public string Author { get; set; }

    }

}