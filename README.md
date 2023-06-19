# 描述
## 帮助进行.NET Web API开发的Nuget包，正在持续完善中...
### 源码见<https://github.com/eternal-heart-k/Bubble.Library>
<br>

## 说明
1. 生命周期的依赖注入
    - 共有三个接口：IScopeDependency、ISingletonDependency、ITransientDependency。
    - 对于每一对Service和IService，在Service接口引入中根据需求再添加以上三种生命周期接口中的一种。
    - 在项目启动程序Program.cs中，添加示例代码实现自动依赖注入：`RegisterLifeCycle.AddCustomServices(builder.Services);`。
2. EF Core
    1. Entity类<br>
    实体类继承`Entity`类可默认包含`int`类型的`Id`字段主键，若需要其他类型的主键，比如`string`类型，可继承`Entity<string>`扩展类。
    2. IsDeleted接口<br>
    实体类实现`IsDeleted`接口后，在使用EF Core查询会自动过滤`IsDeleted=true`的数据。
    3. IHasCreationTime接口<br>
    实体类实现`IHasCreationTime`接口后，在使用EF Core新增数据时，会自动赋值`CreationTime=DateTime.Now`。
    4. IHasModificationTime接口<br>
    实体类实现`IHasModificationTime`接口后，在使用EF Core修改数据时，会自动赋值`LastModificationTime=DateTime.Now`。
    5. IHasDeletionTime接口<br>
    实体类实现`IHasDeletionTime`接口后，在使用EF Core删除数据时，会自动赋值`DeletionTime=DateTime.Now`，同时实现`IsDeleted`接口的话，会将删除状态转换为修改状态，并把`IsDeleted`设置为`true`。
3. 阿里云
    1. 短信验证码
    支持单个发送和批量发送，批量发送一次最多支持100个
    2. OSS存储
    目前支持有上传图片接口，后续会更新上传文件、视频等接口
4. 待更新...

