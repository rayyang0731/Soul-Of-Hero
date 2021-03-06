---
--- UIView
---

---@class UIView
---@field name string 指令标签名称
local _M = { _VERSION = "1.0" }
local mt = { __index = _M }
local log = Log.Create("UIView")
----------------------------------------------------------------------------------

---中介器字典
local mediatorMap = {}

---子界面字典
local childViewMap = {}

--region ----------构造函数----------

---@param tag string 指令标签名称
function _M:new(tag)
    return setmetatable({ name = tag, Facade = LuaFacade }, mt)
end

--endregion

--region ----------私有函数----------

---注册指令监听
function _M:RegisterCommands()

end

---注销指令监听
function _M:UnregisterCommands()

end

---添加 Element(Mediator 中介器)
---@param moduleName string 中介器模块名称
---@param mediatorName string 中介器对象名称(可以传 nil,nil 时等于 moduleName)
---@return AbstractMediator 中介器对象
function _M:AddMediator(moduleName, mediatorName)
    local mediator = LuaFacade.RegisterMediator(moduleName, mediatorName)
    if mediator ~= nil then
        mediatorMap[mediator.name] = mediator
    end
    return
end

---移除全部 Element(Mediator 中介器)
function _M:RemoveAllMediator()
    for name, _ in pairs(mediatorMap) do
        LuaFacade.RemoveMediator(name)
    end

    mediatorMap = nil
    mediatorMap = {}
end

---打开其他界面
---@param viewName string 要打开的界面名称
---@param viewAlias string 界面的别名(可以传 nil,nil 时等于 viewName)
function _M:OpenOtherView(viewName, viewAlias)
    --ViewManager.Instance:OpenView(viewName)
    --TODO: UIManager.OpenView(viewName,viewAlias)
end

---打开子界面
---打开一个指定名称的界面作为此界面的子界面
---当调用此界面的 OnViewResume, OnViewShow, OnViewHide 方法时, 同时调用子界面的这些方法
---在关闭此界面时, 会先关闭子界面, 再关闭自己
---@param viewName string 要打开的界面名称
---@param viewAlias string 界面的别名(可以传 nil,nil 时等于 viewName)
function _M:OpenChildView(viewName, viewAlias)
    --TODO:childViewMap[view] = UIManager.OpenView(viewName,viewAlias)
end

---剥离子界面
---@param viewName string 要剥离的子界面名称
function _M:DetachChildView(viewName)
    if childViewMap[viewName] ~= nil then
        childViewMap[viewName] = nil
    end
end

function _M:Resume()
    
end

--endregion

return _M

        /// <summary>
/// 拉起界面
/// </summary>
public void Resume()
{
OnViewResume();
ChildViews.ForEach(view => view.Value.Resume());
}

/// <summary>
/// 显示界面
/// </summary>
public void Show()
{
OnViewShow();
ChildViews.ForEach(view => view.Value.Show());
}

/// <summary>
/// 隐藏界面
/// </summary>
public void Hide()
{
OnViewHide();
ChildViews.ForEach(view => view.Value.Hide());
}

/// <summary>
/// 关闭界面
/// </summary>
public void Close()
{
UnregisterCommands();
RemoveAllElements();

OnViewClosed();
}

#endregion

#region View Lifecycle Methods

/// <summary>
/// 当界面被创建
/// <para>相当于MonoBehaviour.Awake</para>
/// <para>只操作数据, 不操作界面中的对象</para>
/// </summary>
protected virtual void OnViewCreated()
{
}

/// <summary>
/// 当界面实例化完成
/// <para>相当于 MonoBehaviour.Start</para>
/// </summary>
protected virtual void OnViewOpened()
{
}

/// <summary>
/// 界面Update
/// <para>相当于 MonoBehaviour.Update</para>
/// </summary>
protected virtual void OnViewUpdate()
{
}

/// <summary>
/// 界面 LateUpdate
/// <para>相当于 MonoBehaviour.LateUpdate</para>
/// </summary>
protected virtual void OnViewLateUpdate()
{
}

/// <summary>
/// 当界面关闭
/// </summary>
protected virtual void OnViewClosed()
{
}

/// <summary>
/// 当界面被删除
/// 相当于 MonoBehaviour.OnDestroy
/// </summary>
protected virtual void OnViewDestroyed()
{
}

/// <summary>
/// 当界面被拉起
/// <para>当从其他界面回到本界面或再次打开本界面时调用</para>
/// </summary>
protected virtual void OnViewResume()
{
}

/// <summary>
/// 当界面显示时调用
/// </summary>
protected virtual void OnViewShow()
{
}

/// <summary>
/// 当界面隐藏时调用
/// </summary>
protected virtual void OnViewHide()
{
}

#endregion

#region Unity Lifecycle Methods

protected sealed override void OnAwake()
{
OnViewCreated();
}

protected void Start()
{
OnViewOpened();
RegisterCommands();
RegisterElements();
}

public sealed override void OnUpdate()
{
OnViewUpdate();
}

public sealed override void OnLateUpdate()
{
OnViewLateUpdate();
}

protected sealed override void OnDestroyed()
{
OnViewDestroyed();
}

#endregion
}