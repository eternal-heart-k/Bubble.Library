namespace Bubble.Library.DataBase.Interface
{
    /// <summary>
    /// 实体软删除标记属性接口
    /// IsDeleted = true为已删除
    /// 删除逻辑可转为修改逻辑
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
