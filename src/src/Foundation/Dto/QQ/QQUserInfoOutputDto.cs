using System.Text.Json.Serialization;

namespace Bubble.Library.Foundation.Dto.QQ
{
    /// <summary>
    /// 获取QQ用户信息出参
    /// </summary>
    public class QQUserInfoOutputDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonPropertyName("ret")]
        public int Ret { get; set; }

        /// <summary>
        /// 如果ret小于0，会有相应的错误信息提示，返回数据全部用UTF-8编码
        /// </summary>
        [JsonPropertyName("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 判断是否有数据丢失。如果应用不使用cache，不需要关心此参数
        /// 0或者不返回：没有数据丢失，可以缓存。1：有部分数据丢失或错误，不要缓存
        /// </summary>
        [JsonPropertyName("is_lost")]
        public int IsLost { get; set; }

        /// <summary>
        /// 用户在QQ空间的昵称
        /// </summary>
        [JsonPropertyName("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// 大小为30×30像素的QQ空间头像URL
        /// </summary>
        [JsonPropertyName("figureurl")]
        public string FigureUrl { get; set; }

        /// <summary>
        /// 大小为50×50像素的QQ空间头像URL
        /// </summary>
        [JsonPropertyName("figureurl_1")]
        public string FigureUrl1 { get; set; }

        /// <summary>
        /// 大小为100×100像素的QQ空间头像URL
        /// </summary>
        [JsonPropertyName("figureurl_2")]
        public string FigureUrl2 { get; set; }

        /// <summary>
        /// 大小为40×40像素的QQ头像URL
        /// </summary>
        [JsonPropertyName("figureurl_qq_1")]
        public string FigureUrlQQ1 { get; set; }

        /// <summary>
        /// 大小为100×100像素的QQ头像URL
        /// 需要注意，不是所有的用户都拥有QQ的100x100的头像，但40x40像素则是一定会有
        /// </summary>
        [JsonPropertyName("figureurl_qq_2")]
        public string FigureUrlQQ2 { get; set; }

        /// <summary>
        /// 性别。 如果获取不到则默认返回"男"
        /// </summary>
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// 性别类型。默认返回2
        /// </summary>
        [JsonPropertyName("gender_type")]
        public int GenderType { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [JsonPropertyName("province")]
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        [JsonPropertyName("year")]
        public string Year { get; set; }

        /// <summary>
        /// 星座
        /// </summary>
        [JsonPropertyName("constellation")]
        public string Constellation { get; set; }

        /// <summary>
        /// 标识用户是否为黄钻用户
        /// </summary>
        [JsonPropertyName("is_yellow_vip")]
        public string IsYellowVip { get; set; }

        /// <summary>
        /// 黄钻等级
        /// </summary>
        [JsonPropertyName("yellow_vip_level")]
        public string YellowVipLevel { get; set; }

        /// <summary>
        /// 是否为年费黄钻用户
        /// </summary>
        [JsonPropertyName("is_yellow_year_vip")]
        public string IsYellowYearVip { get; set; }
    }
}
