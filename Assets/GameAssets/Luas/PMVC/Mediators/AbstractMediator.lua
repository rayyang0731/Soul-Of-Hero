---
--- AbstractMediator
---

---@alias Mediator.Observe {notifyCode:NotifySystem.Code, method:function}

---@class AbstractMediator
---@field name string 代理标签名称
---@field Facade LuaFacade Lua 外观角色
---@field view LuaBaseView Lua 界面基类
local _M = { _VERSION = "1.0" }
local mt = { __index = _M }

local log = Log.Create("AbstractMediator")
----------------------------------------------------------------------------------

---内部消息列表
---@type Mediator.Observe[]
local notifyList = {}

--region ----------构造函数----------

---@param tag string 中介器标签名称
---@return AbstractMediator
function _M:new(tag)
    return setmetatable({ name = tag, Facade = LuaFacade }, mt)
end

--endregion

--region ----------protected方法----------

---加载时调用
local function OnLoad()
    log:Info("Mediator 基类,不应该调用到此类的 OnLoad 方法,请检查[", self.name, "]指令模块")
end

---卸载时调用
local function OnUnload()
    log:Info("Mediator 基类,不应该调用到此类的 OnUnload 方法,请检查[", self.name, "]指令模块")
end

--endregion

--region ----------公共方法----------

---注册时调用
function _M:OnRegister()
    OnLoad()
end

---移除时调用
function _M:OnRemove()
    OnUnload()
    self:RemoveAllListeners()
end

---添加针对中介器的监听器,方便在中介器移除时,注销此中介器添加的监听
---@param notifyCode NotifySystem.Code 消息号
---@param method NotifySystem.Function 通知事件
function _M:AddListener(notifyCode, method)
    notifyList = notifyList or {}
    local observe = { notifyCode = notifyCode, method = method }
    table.insert(notifyList, observe)
    NotifySystem.AddListener(notifyCode, method)
end

---移除监听
---@param notifyCode NotifySystem.Code 消息号
---@param method NotifySystem.Function 通知事件
function _M:RemoveListener(notifyCode, method)
    NotifySystem.RemoveListener(notifyCode, method)

    local wannaRemoveIndex = -1
    for i, observe in ipairs(notifyList) do
        if observe.notifyCode.Block == notifyCode.Block and observe.notifyCode.Code == notifyCode.Code and
                observe.method == method then
            wannaRemoveIndex = i
            break
        end
    end
    if wannaRemoveIndex > 0 then
        table.remove(notifyList, wannaRemoveIndex)
    end
end

---移除全部监听
function _M:RemoveAllListeners()
    if notifyList == nil or #notifyList == 0 then
        return
    end

    for i, observe in ipairs(notifyList) do
        NotifySystem.RemoveListener(observe.notifyCode, observe.method)
    end
end

--endregion

return _M