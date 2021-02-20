using KiwiFramework.Core;
using KiwiFramework.Core.Interface;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏启动指令
/// </summary>
public class StartupCommand : Command
{
    public override void Execute(INotice note)
    {
        KiwiLog.Info("startup..");

        Facade.RemoveCommand(CMD_TAG.STARTUP);

        SceneManager.LoadScene("Game");

        Facade.RegisterCommand<LoginCommand>(CMD_TAG.LOGIN);

        SendNotify(CMD_TAG.LOGIN);
    }
}