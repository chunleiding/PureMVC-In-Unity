using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class MessageName
{
    public const int ID_INITIALNUM = 1;
    public const int ID_ADDLEVEL = 2;
    public const int ID_SUBTRACTLEVEL = 3;
}

public class MessageID
{
    public const ushort a = 0;
    public const ushort b = 1;
    public const ushort c = 2;
    public const ushort d = 3;
    public const ushort e = 4;
    public const ushort f = 5;
    public const ushort g = 6;
    public const ushort h = 7;
    public const ushort i = 8;
}

/// <summary>
/// controller:数据控制类,接收玩家的输入;
/// </summary>
public class DataCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        DataProxyModel datapro = notification.Body as DataProxyModel;

        if (notification.Type == "0")
        {
            SendNotification("InitalNum", datapro.Data);
        }
        else if (notification.Type == "1")
        {
            datapro.AddLevel(10);
            SendNotification("Msg_AddLevel", datapro.Data);
        }
        else if (notification.Type == "2")
        {
            datapro.ReduceLevel(10);

            SendNotification("Msg_ReduceLevel", datapro.Data);
        }
    }

}
