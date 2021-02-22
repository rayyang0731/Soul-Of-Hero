using KiwiFramework.Core;
using KiwiFramework.Core.Interface;

/// <summary>
/// 账号登陆指令
/// </summary>
public class AccountSignInCommand : Command
{
    public override void Execute(INotice notice)
    {
        var data = (KV<string, string>) notice.Body;
        var account = data.Key;
        var password = data.Value;
        KiwiLog.Info("Try To Login Account - account : ", account, " | password : ", password);

        var loginProxy = Facade.GetProxy<LoginProxy>();
        loginProxy.account = account;
        loginProxy.password = password;

        SendNotify(CMD_TAG.SIGN_IN_SUCCESSFUL);
    }
}