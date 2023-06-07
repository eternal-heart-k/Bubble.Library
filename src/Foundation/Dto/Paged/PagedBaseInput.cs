namespace Bubble.Library.Foundation.Dto.Paged
{
    /// <summary>
    /// 分页入参
    /// </summary>
    public class PagedBaseInput
    {
        /// <summary>
        /// 当前页的下标
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页数据量大小
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
