using System;

namespace Bubble.Library.DataBase.Interface
{
    /// <summary>
    /// 实体上次修改时间属性接口
    /// </summary>
    public interface IHasModificationTime
    {
        /// <summary>
        /// 上一次修改时间
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }
}
