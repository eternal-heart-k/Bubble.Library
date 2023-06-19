namespace Bubble.Library.Foundation.Dto.Aliyun
{
    public class SmsBaseDto
    {
        public string EndPoint { get; set; } = "dysmsapi.aliyuncs.com";

        public string AccessKeyId { get; set; }

        public string AccessKeySecret { get; set; }
    }
}
