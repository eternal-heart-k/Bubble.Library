using Bubble.Library.Foundation.Dto.Aliyun;
using Bubble.Library.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Aliyun.OSS;
using Aliyun.OSS.Common;
using Microsoft.Extensions.Logging;

namespace Bubble.Library.Aliyun.Oss
{
    public class OssService : IOssService, ITransientDependency
    {
        private readonly ILogger<OssService> _logger;

        public OssService(ILogger<OssService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 上传单个图片，返回图片地址
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public string UploadImage(IFormFile formFile, OssInputDto dto)
        {
            var client = new OssClient(dto.EndPoint, dto.AccessKeyId, dto.AccessKeySecret);
            try
            {
                client.PutObject(dto.BucketName, dto.StorePath, formFile.OpenReadStream());
                return dto.StoreBasePath + dto.StorePath;
            }
            catch (OssException ex)
            {
                _logger.LogError($"单个上传图片失败，异常消息是：{ex.Message}", ex);
                throw;
            }
        }

        /// <summary>
        /// 异步上传单个图片，返回图片地址
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<string> UploadImageAsync(IFormFile formFile, OssInputDto dto)
        {
            return await Task.Run(() => UploadImage(formFile, dto));
        }
    }
}
