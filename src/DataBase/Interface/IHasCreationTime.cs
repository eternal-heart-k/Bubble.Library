using System;

namespace Bubble.Library.DataBase.Interface
{
    /// <summary>
    /// 实体创建时间属性接口
    /// </summary>
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}
