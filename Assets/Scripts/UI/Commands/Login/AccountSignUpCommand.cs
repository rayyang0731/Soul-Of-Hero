using KiwiFramework.Core;
using KiwiFramework.Core.Interface;

/// <summary>
/// 账号注册指令
/// </summary>
public class AccountSignUpCommand : Command
{
    public override void Execute(INotice notice)
    {
        var data = (KV<string, string>) notice.Body;
        var account = data.Key;
        var password = data.Value;
        KiwiLog.Info("account : ", account, " | password : ", password);

        var loginProxy = Facade.GetProxy<LoginProxy>();
        loginProxy.account = account;
        loginProxy.password = password;

        SendNotify(CMD_TAG.SIGN_IN_SUCCESSFUL);
    }
}