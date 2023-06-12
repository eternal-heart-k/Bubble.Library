# 描述
## 帮助进行.NET Web API开发的Nuget包，正在持续完善中...
### 源码见<https://github.com/eternal-heart-k/Bubble.Library>
<br>

## 说明
1. 生命周期的依赖注入：IScopeDependency、ISingletonDependency、ITransientDependency
- 对于每一对Service和IService，在Service接口引入中根据需求再添加以上三种生命周期接口中的一种
- 在项目启动程序Program.cs中，添加以下代码实现自动依赖注入
    ```
    RegisterLifeCycle.AddCustomServices(builder.Services);
    ```
2. 待更新
