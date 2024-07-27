using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
/// <summary>
/// View层:显示玩家UI界面
/// </summary>
public class DataMediator : Mediator
{
    public DataMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
    {
        //获取View层的组件在这里进行事件绑定;
        MediatorName = mediatorName;
        ViewComponent = viewComponent;
    }

    public override string[] ListNotificationInterests()
    {
        return new string[]{
            "Msg_AddLevel",
            "Msg_ReduceLevel",
            "InitalNum"
        };
    }
    public override void OnRegister()
    {
        base.OnRegister();

        var panel = ViewComponent as ViewPanel;
        panel.BtnDisplayAddLevelNum.onClick.AddListener(() =>
        {
            OnClickAddingLevelNumber();
        });

        panel.BtnDisplayReduceLevelNum.onClick.AddListener(() =>
        {
            OnClickSubtractingLevelNumber();
        });

    }

    public override void HandleNotification(INotification notification)
    {
        var panel = ViewComponent as ViewPanel;
        var model = notification.Body as DataEntityModel;
        if (notification.Name == "Msg_AddLevel")
        {
            panel.TxtLevel.text = model.Level.ToString();
        }
        else if (notification.Name == "Msg_ReduceLevel")
        {
            panel.TxtLevel.text = model.Level.ToString();
        }
        else if (notification.Name == "InitalNum")
        {
            panel.TxtLevel.text = model.Level.ToString();
        }
    }

    //用户点击增加事件
    private void OnClickAddingLevelNumber()
    {
        //定义消息，发消息到”控制层“
        SendNotification("Reg_StartDataCommand", Facade.RetrieveProxy(typeof(DataProxyModel).Name), "1");
    }

    //用户点击减少事件
    private void OnClickSubtractingLevelNumber()
    {
        //定义消息，发消息到”控制层“
        SendNotification("Reg_StartDataCommand", Facade.RetrieveProxy(typeof(DataProxyModel).Name), "2");
    }

}
