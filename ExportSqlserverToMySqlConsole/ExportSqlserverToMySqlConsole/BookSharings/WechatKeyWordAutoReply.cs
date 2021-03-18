using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadBook.ManagementPlatform
{
    public class WechatKeyWordAutoReply
    {
        [Required]
        [StringLength(100)]
        public string KeyWord { get; set; }

        public WechatAutoReplyKeywordMatchType MatchType { get; set; }

        /// <summary>
        /// 是否支持菜单事件关键字触发
        /// </summary>
        public bool AllowEventKeyTrigger { get; set; }

        public int TenantId { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
