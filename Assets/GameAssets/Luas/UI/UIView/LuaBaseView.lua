---
--- LuaBaseView
---

---@class LuaBaseView
---@field name string 指令标签名称
local _M = { _VERSION = "1.0" }
local mt = { __index = _M }
local log = Log.Create("LuaBaseView")
----------------------------------------------------------------------------------

---中介器字典
---@type table<string,AbstractMediator>
local mediatorMap = {}

---子界面字典
---@type table<string,LuaBaseView>
local childViewMap = {}

--region ----------构造函数----------

---@param tag string 界面名称
---@return LuaBaseView
function _M:new(tag)
    local m = setmetatable({ name = tag, Facade = LuaFacade }, mt)
    m:OnAwake()
    return m
end

--endregion

--region ----------Fixed Methods----------

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
    UIManager.OpenView(viewName, viewAlias)
end

---打开子界面
---打开一个指定名称的界面作为此界面的子界面
---当调用此界面的 OnViewResume, OnViewShow, OnViewHide 方法时, 同时调用子界面的这些方法
---在关闭此界面时, 会先关闭子界面, 再关闭自己
---@param viewName string 要打开的界面名称
---@param viewAlias string 界面的别名(可以传 nil,nil 时等于 viewName)
function _M:OpenChildView(viewName, viewAlias)
    childViewMap[view] = UIManager.OpenView(viewName, viewAlias)
end

---剥离子界面
---@param viewName string 要剥离的子界面名称
function _M:DetachChildView(viewName)
    if childViewMap[viewName] ~= nil then
        childViewMap[viewName] = nil
    end
end

---拉起界面
function _M:Resume()
    self:OnViewResume()
    for _, childView in pairs(childViewMap) do
        childView:Resume()
    end
end

---显示界面
function _M:Show()
    self:OnViewShow()
    for _, childView in pairs(childViewMap) do
        childView:Show()
    end
end

---隐藏界面
function _M:Hide()
    self:OnViewHide()
    for _, childView in pairs(childViewMap) do
        childView:Hide()
    end
end

---关闭界面
function _M:Close()
    self:UnregisterCommands()
    self:RemoveAllMediator()

    self:OnViewClosed()
end

--endregion

--region ----------Virtual Methods----------

---注册指令监听
function _M:RegisterCommands()

end

---注销指令监听
function _M:UnregisterCommands()

end

---当界面被创建
---相当于MonoBehaviour.Awake
---只操作数据, 不操作界面中的对象
function _M:OnViewCreated()
    log:Info("OnViewCreated")
end

---当界面实例化完成
---相当于 MonoBehaviour.Start
function _M:OnViewOpened()

end

---界面Update
---相当于 MonoBehaviour.Update
function _M:OnViewUpdate()

end

---界面 LateUpdate
---相当于 MonoBehaviour.LateUpdate
function _M:OnViewLateUpdate()

end

---当界面关闭
function _M:OnViewClosed()

end

---当界面被删除
---相当于 MonoBehaviour.OnDestroy
function _M:OnViewDestroyed()

end

---当界面被拉起
---当从其他界面回到本界面或再次打开本界面时调用
function _M:OnViewResume()

end

---当界面显示时调用
function _M:OnViewShow()

end

---当界面隐藏时调用
function _M:OnViewHide()

end

--endregion

--region ----------Lifecycle Methods----------

function _M:OnAwake()
    self:OnViewCreated()
end

function _M:OnUpdate()
    self:OnViewUpdate()
end

function _M:OnLateUpdate()
    self:OnViewLateUpdate()
end

function _M:OnDestroyed()
    self:OnViewDestroyed()
end

--endregion

return _M