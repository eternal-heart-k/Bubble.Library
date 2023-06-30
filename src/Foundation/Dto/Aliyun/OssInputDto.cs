﻿namespace Bubble.Library.Foundation.Dto.Aliyun
{
    /// <summary>
    /// OSS入参
    /// </summary>
    public class OssInputDto
    {
        /// <summary>
        /// 地域节点例如：https://oss-cn-YourArea.aliyuncs.com
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccessKeySecret { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// 存储基地址，例如：https://YourName.oss-cn-YourArea.aliyuncs.com/
        /// </summary>
        public string StoreBasePath { get; set; } = string.Empty;

        /// <summary>
        /// 存储路径
        /// </summary>
        public string StorePath { get; set; }
    }
}
