using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SqlSugar;

namespace ExportSqlserverToMySqlConsole.BookSharings
{
    public class BookResources 
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public int ResourceType { get; set; }

        [StringLength(500)]
        public string ResourceLink { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }
        [StringLength(500)]
        public string FileName { get; set; }

        public long? FileSize { get; set; }
        [StringLength(500)]
        public string ResourceLinkCode { get; set; }
        [StringLength(500)]
        public string VipResourceLink { get; set; }
        [StringLength(500)]
        public string VipResourceLinkCode { get; set; }

        public int BookId { get; set; }
        [StringLength(500)]
        public string PhysicalPath { get; set; }
    }

}