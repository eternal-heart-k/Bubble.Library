using System.Collections.Generic;

namespace Bubble.Library.Foundation.Dto.Paged
{
    /// <summary>
    /// 分页结果
    /// </summary>
    public class PagedResultDto<T>
    {
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 当前页的数据信息（只读）
        /// </summary>
        public IReadOnlyList<T> Items { get; set; }
    }
}
