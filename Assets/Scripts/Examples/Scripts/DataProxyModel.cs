using PureMVC.Patterns.Proxy;
/// <summary>
/// Model模型层
/// </summary>
public class DataProxyModel : Proxy
{
    //引用“实体类”
    private DataEntityModel _MyDataModel = null;
    /// <summary>
    /// 构造函数
    /// </summary>
    public DataProxyModel(string name = null) : base(name)
    {
        _MyDataModel = new DataEntityModel();
        Data = _MyDataModel;
        SendNotification("Reg_StartDataCommand", this, "0");
    }

    /// <summary>
    /// 增加等级
    /// </summary>
    /// <param name="addNumber">增加的等级数量</param>
    public void AddLevel(int addNumber)
    {
        _MyDataModel.Level += addNumber;
    }

    public void ReduceLevel(int reduceNumber)
    {
        _MyDataModel.Level -= reduceNumber;
    }
}

/// <summary>
/// 数据实体类
/// </summary>
public class DataEntityModel
{
    private int _Level = 0;

    /// <summary>
    /// 玩家等级
    /// </summary>
    public int Level { get => _Level; set => _Level = value; }
}