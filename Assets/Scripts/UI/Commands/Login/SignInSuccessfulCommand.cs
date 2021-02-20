using KiwiFramework.Core;
using KiwiFramework.Core.Interface;
using UnityEngine;

/// <summary>
/// 登陆成功指令
/// </summary>
public class SignInSuccessfulCommand : Command
{
    public override void Execute(INotice note)
    {
        var loginProxy = Facade.GetProxy<LoginProxy>();
        PlayerPrefs.SetString("account", loginProxy.account);
        PlayerPrefs.SetString("password", loginProxy.password);
        KiwiLog.Info("登陆成功 account : ", loginProxy.account, " | password : ", loginProxy.password);
    }
}