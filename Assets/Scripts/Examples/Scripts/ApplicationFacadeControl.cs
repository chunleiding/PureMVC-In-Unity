using PureMVC.Interfaces;
using PureMVC.Patterns.Facade;
using UnityEngine;
/// <summary>
/// MVC控制器
/// </summary>
public class ApplicationFacadeControl : Facade
{

    /// <summary>
    /// 开放注册接口,把依赖传递进来;
    /// </summary>
    /// <param name="panel"></param>
    public void Register<T, U, V>(T mediator, U command, V proxy, string notificationName) where T : IMediator where U : ICommand where V : IProxy
    {
        RegisterMediator(mediator);
        RegisterCommand(notificationName, () => command);
        RegisterProxy(proxy);
    }
}
