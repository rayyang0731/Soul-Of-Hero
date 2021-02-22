using KiwiFramework.Core;
using KiwiFramework.Core.Interface;
using UnityEngine.SceneManagement;

public class LoginCommand : Command
{
    public override void Execute(INotice note)
    {
        SceneManager.LoadScene("Login", LoadSceneMode.Additive);
        ViewManager.Instance.OpenView("UILoginView");
    }
}