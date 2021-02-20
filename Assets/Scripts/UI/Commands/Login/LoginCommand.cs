using KiwiFramework.Core;
using KiwiFramework.Core.Interface;

public class LoginCommand : Command
{
    public override void Execute(INotice note)
    {
        ViewManager.Instance.OpenView("UILoginView");
    }
}