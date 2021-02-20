using System.Collections;
using System.Collections.Generic;
using KiwiFramework.Core;
using KiwiFramework.UI;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseUILoginView : BaseView
{
    private TMP_InputField _input_account;

    ///input_account
    public TMP_InputField input_account
    {
        get
        {
            if (!_input_account)
                _input_account = define.viewObjectBinder.Get(0) as TMP_InputField;
            return _input_account;
        }
    }

    private TMP_InputField _input_password;

    ///input_password
    public TMP_InputField input_password
    {
        get
        {
            if (!_input_password)
                _input_password = define.viewObjectBinder.Get(1) as TMP_InputField;
            return _input_password;
        }
    }

    private UIButton _btn_login;

    ///btn_login
    public UIButton btn_login
    {
        get
        {
            if (!_btn_login)
                _btn_login = define.viewObjectBinder.Get(2) as UIButton;
            return _btn_login;
        }
    }

    private UIButton _btn_register;

    ///btn_register
    public UIButton btn_register
    {
        get
        {
            if (!_btn_register)
                _btn_register = define.viewObjectBinder.Get(3) as UIButton;
            return _btn_register;
        }
    }
}