using System;

namespace Bubble.Library.DataBase.Interface
{
    /// <summary>
    /// 实体删除时间属性接口
    /// </summary>
    public interface IHasDeletionTime : ISoftDelete
    {
        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? DeletionTime { get; set; }
    }
}
