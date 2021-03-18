using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadBook.ManagementPlatform
{
    public enum WechatAutoReplyKeywordMatchType
    {
        /// <summary>
        /// 包含
        /// </summary>
        [Display(Name = "包含")]
        Contains,
        /// <summary>
        /// 等于
        /// </summary>
        [Display(Name = "等于")]
        Equals
    }

    public enum WechatAutoReplyKeyWordContentType
    {
        /// <summary>
        /// 文本
        /// </summary>
        [Display(Name = "文本")]
        Text = 0,
        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name = "图片")]
        Image = 1,
        ///// <summary>
        ///// 音乐
        ///// </summary>
        //[Display(Name = "音乐")]
        //[AttachData(AttachDataEnum.Text, "音乐")]
        //Music = 2,
        /// <summary>
        /// 语音
        /// </summary>
        [Display(Name = "语音")]
        Voice = 3,
        /// <summary>
        /// 视频
        /// </summary>
        [Display(Name = "视频")]
        Video = 4,
        /// <summary>
        /// 图文
        /// </summary>
        [Display(Name = "图文")]
        News = 5,
        [Display(Name = "本地图文")]
        LocalNews = 6,
        [Display(Name = "小程序卡片")]
        MiniprogramCard = 7
    }


    public class WechatKeyWordAutoReplyItem
    {
        public WechatAutoReplyKeyWordContentType KeyWordContentType { get; set; }

        [StringLength(200)]
        public string MediaId { get; set; }
        [StringLength(4000)]
        public string TextContent { get; set; }
        [StringLength(500)]
        public string FileName { get; set; }

        [Display(Name = "开始时间")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "结束时间")]
        public DateTime? EndTime { get; set; }

        [StringLength(2000)]
        public string Title { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }


        public int WechatKeyWordAutoReplyId { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int TenantId { get; set; }
    }
}
