using System.Threading.Tasks;
using Bubble.Library.Foundation.Dto.Aliyun;
using Microsoft.AspNetCore.Http;

namespace Bubble.Library.Aliyun.Oss
{
    /// <summary>
    /// OSS存储
    /// </summary>
    public interface IOssService
    {
        /// <summary>
        /// 上传单个图片，返回图片地址
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        string UploadImage(IFormFile formFile, OssInputDto dto);

        /// <summary>
        /// 上传单个图片，返回图片地址（异步）
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<string> UploadImageAsync(IFormFile formFile, OssInputDto dto);
    }
}
