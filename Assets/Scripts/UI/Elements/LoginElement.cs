using KiwiFramework.Core;
using KiwiFramework.UI;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoginElement : Element
{
    public TMP_InputField _input_account;
    public TMP_InputField _input_password;

    public UIButton _btn_login;
    public UIButton _btn_register;

    protected override void OnLoad()
    {
        if (PlayerPrefs.HasKey("account"))
            _input_account.text = PlayerPrefs.GetString("account");
        if (PlayerPrefs.HasKey("password"))
            _input_password.text = PlayerPrefs.GetString("password");

        _btn_login.AddButtonClickEvent(ClickLoginButton);
        _btn_register.AddButtonClickEvent(ClickRegisterButton);
    }

    /// <summary>
    /// 点击登录按钮
    /// </summary>
    private void ClickLoginButton()
    {
        if (string.IsNullOrEmpty(_input_account.text) && string.IsNullOrEmpty(_input_password.text))
            return;

        SendNotify(CMD_TAG.ACCOUNT_SIGN_IN,
            new KV<string, string>(_input_account.text, _input_password.text));
    }

    /// <summary>
    /// 点击注册按钮
    /// </summary>
    private void ClickRegisterButton()
    {
        if (string.IsNullOrEmpty(_input_account.text) && string.IsNullOrEmpty(_input_password.text))
            return;

        SendNotify(CMD_TAG.ACCOUNT_SIGN_UP,
            new KV<string, string>(_input_account.text, _input_password.text));
    }

    protected override void OnUnload()
    {
        _btn_login.RemoveButtonClickEvent(ClickLoginButton);
        _btn_register.RemoveButtonClickEvent(ClickRegisterButton);
    }
}