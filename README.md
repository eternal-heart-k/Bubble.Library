## 描述
一个帮助进行.NET Web API开发的Nuget包，正在持续完善中...<br>

## 近期改动
1. 可使用以下构建代码进行项目的构建启动，如需数据等其他配置可在`LibraryBuilderConfiguration`里携带
```
LibraryBuilder.InitializeApplication(args, new LibraryBuilderConfiguration());
```
2. ApiResult改动（破坏行更改）
原先继承ApiBaseController即可实现，现在使用以上的代码构建，内部会通过`ApiResultAttachFilter`和`ExceptionFilter`自动实现。
此外ApiBaseController去除了此特性，如需升级包，可使用以上构建方式。

## 功能说明
### 生命周期的依赖注入
- 共有三个接口：IScopeDependency、ISingletonDependency、ITransientDependency。
- 对于每一对Service和IService，在Service接口引入中根据需求再添加以上三种生命周期接口中的一种。
- 内部会使用AutoFac自动进行依赖注入

### EF Core
- Entity类<br>
实体类继承`Entity`类可默认包含`int`类型的`Id`字段主键，若需要其他类型的主键，比如`string`类型，可继承`Entity<string>`扩展类。
- IsDeleted接口<br>
实体类实现`IsDeleted`接口后，在使用EF Core查询会自动过滤`IsDeleted=true`的数据。
- IHasCreationTime接口<br>
实体类实现`IHasCreationTime`接口后，在使用EF Core新增数据时，会自动赋值`CreationTime=DateTime.Now`。
- IHasModificationTime接口<br>
实体类实现`IHasModificationTime`接口后，在使用EF Core修改数据时，会自动赋值`LastModificationTime=DateTime.Now`。
- IHasDeletionTime接口<br>
实体类实现`IHasDeletionTime`接口后，在使用EF Core删除数据时，会自动赋值`DeletionTime=DateTime.Now`，同时实现`IsDeleted`接口的话，会将删除状态转换为修改状态，并把`IsDeleted`设置为`true`。
### 阿里云
#### 短信验证码
Service注入`ISmsService`可调用短信验证码相关函数：支持单个发送和批量发送短信验证码，批量发送一次最多支持100个。
#### OSS存储
Service注入`IOssService`可调用OSS存储相关函数：目前支持有上传图片函数，后续会更新上传文件、视频等函数。
### 接口统一返回类ApiResult
接口继承`ApiBaseController`类后，返回值会自动引入`ApiResult`类：
- `Result`：返回值（当接口有返回值时有）
- `IsSuccess`：接口执行成功标识
- `Message`：错误信息，结合`StringResponseException`异常，抛出的错误信息会体现在这。
- `ErrorCode`：错误代码
- `OperationId`：操作Id
### QQ
#### 快速登录
Service注入`IQQService`可调用QQ相关函数，因逻辑可能每个人实现会有所不同，所以这里实现了以下四个基本的阶段函数：
1. `GetAuthorizationLink`：入参`QQAuthorizationCodeInputDto`，返回封装好的QQ授权的链接地址<br>
注：此步骤生成的`state`，最好在回调接口中进行检验，可存储在redis中以便校验
2. `GetAccessTokenAsync`：入参`QQAccessTokenInputDto`，返回`QQAccessTokenOutputDto`包含`AccessToken`等字段
3. `GetOpenIdAsync`：入参`QQOpenIdInputDto`，返回`QQOpenIdOutputDto`包含`OpenId`等字段
4. `GetUserInfoAsync`：入参`QQUserInfoInputDto`，返回`QQUserInfoOutputDto`包含QQ用户的基本信息
### 请求
#### IServiceClient
调用相关函数进行相应的HTTP请求
#### IResilientServiceClient
可重试的调用相关函数进行相应的HTTP请求
### 待更新...

