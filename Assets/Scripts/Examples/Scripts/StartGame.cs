using PureMVC.Interfaces;
using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StartGame : MonoBehaviour
{
    ApplicationFacadeControl control;
    [SerializeField]
    ViewPanel panel;
    void Start()
    {
        //RegisterMediator(new DataMediator(typeof(T).Name, panel));
        //RegisterCommand("Reg_StartDataCommand", () => new DataCommand());
        //RegisterProxy(new DataProxyModel("DataProxyModel"));
        control = new ApplicationFacadeControl();
        //ע��MVC;
        control.Register(new DataMediator(typeof(DataMediator).Name, panel),
            new DataCommand(),
            new DataProxyModel("DataProxyModel"),
            "Reg_StartDataCommand");
    }



    private void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 100, 100), "�������Ϣ"))
        {
            var dataModel = control.RetrieveProxy("DataProxyModel");
            var model = dataModel as DataProxyModel;
            var data = model.Data as DataEntityModel;
            data.Level = Random.Range(0, 1100);

            //������Ϣ������Ϣ�������Ʋ㡰
            control.SendNotification("Reg_StartDataCommand", model, "0");
        }
    }

}

