using System.Collections;
using System.Collections.Generic;
using KiwiFramework.Core;
using KiwiFramework.UI;
using UnityEngine;
using UnityEngine.UI;
using XLua;

/// <summary>
/// 登陆界面
/// </summary>
[Hotfix]
public class UILoginView : BaseUILoginView
{
    private LoginElement _loginElement;

    #region Framework

    #region Command

    /// <summary>
    /// 注册指令
    /// </summary>
    protected override void RegisterCommands()
    {
        AppFacade.Instance.RegisterCommand<AccountSignUpCommand>(CMD_TAG.ACCOUNT_SIGN_UP);
        AppFacade.Instance.RegisterCommand<AccountSignInCommand>(CMD_TAG.ACCOUNT_SIGN_IN);
        AppFacade.Instance.RegisterCommand<SignInSuccessfulCommand>(CMD_TAG.SIGN_IN_SUCCESSFUL);
    }

    /// <summary>
    /// 移除指令
    /// </summary>
    protected override void UnregisterCommands()
    {
        AppFacade.Instance.RemoveCommand(CMD_TAG.ACCOUNT_SIGN_UP);
        AppFacade.Instance.RemoveCommand(CMD_TAG.ACCOUNT_SIGN_IN);
        AppFacade.Instance.RemoveCommand(CMD_TAG.SIGN_IN_SUCCESSFUL);
    }

    #endregion

    #region Element

    /// <summary>
    /// 注册 Elements
    /// </summary>
    protected override void RegisterElements()
    {
        var loginElement = CreateElement<LoginElement>(ELEMENT_TAG.LOGIN);
        loginElement._btn_register = btn_register;
        loginElement._btn_login = btn_login;
        loginElement._input_account = input_account;
        loginElement._input_password = input_password;
        AddElement(loginElement);
    }

    #endregion

    #endregion

    #region View Lifecycle Methods

    /// <summary>
    /// 当界面被创建
    /// <para>相当于MonoBehaviour.Awake</para>
    /// <para>只操作数据,不操作界面中的对象</para>
    /// </summary>
    protected override void OnViewCreated()
    {
    }


    /*
    /// <summary>
    /// 当界面实例化完成
    /// <para>相当于 MonoBehaviour.Start</para>
    /// </summary>
    protected override void OnViewOpened()
    {
    }
    */

    /*
    /// <summary>
    /// 界面Update
    /// <para>相当于 MonoBehaviour.Update</para>
    /// </summary>
    protected override void OnViewUpdate()
    {
    }
    */

    /*
    /// <summary>
    /// 界面 LateUpdate
    /// <para>相当于 MonoBehaviour.LateUpdate</para>
    /// </summary>
    protected override void OnViewLateUpdate()
    {
    }
    */


    /// <summary>
    /// 当界面关闭
    /// </summary>
    protected override void OnViewClosed()
    {
    }


    /*
    /// <summary>
    /// 当界面被删除
    /// 相当于 MonoBehaviour.OnDestroy
    /// </summary>
    protected override void OnViewDestroyed()
    {
    }
    */

    /*
    /// <summary>
    /// 当界面被拉起
    /// <para>当从其他界面回到本界面或再次打开本界面时调用</para>
    /// </summary>
    protected override void OnViewResume()
    {
    }
    */

    /*
    /// <summary>
    /// 当界面显示时调用
    /// </summary>
    protected override void OnViewShow()
    {
    }
    */

    /*
    /// <summary>
    /// 当界面隐藏时调用
    /// </summary>
    protected override void OnViewHide()
    {
    }
    */

    #endregion
}