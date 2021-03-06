---
--- LuaFacade.lua
---

_G["NotifySystem"] = require("NotifySystem")

---@class LuaFacade
local _M = { _VERSION = "1.0" }

---@type LuaController
local LuaController = require("LuaController")
---@type LuaModel
local LuaModel = require("LuaModel")
---@type LuaView
local LuaView = require("LuaView")

local log = Log.Create("LuaFacade")
----------------------------------------------------------------------------------

--region ----------Command----------

---注册指令
---@param moduleName string 指令模块名称
function _M.RegisterCommand(moduleName)
    log:Info("Register command : ", moduleName)
    LuaController.RegisterCommand(moduleName)
end

---执行指令
---@param moduleName string 指令模块名称
---@param data table 数据
function _M.ExecuteCommand(moduleName, data)
    log:Info("Execute command : ", moduleName)
    LuaController.ExecuteCommand(moduleName, data)
end

---移除指令
---@param moduleName string 指令模块名称
function _M.RemoveCommand(moduleName)
    log:Info("Remove Command : ", moduleName)
    LuaController.RemoveCommand(moduleName)
end

---移除全部指令
function _M.RemoveAllCommand()
    log:Info("Remove All Command")
    LuaController.RemoveAllCommands()
end

--endregion

--region ----------Proxy----------

---注册数据代理
---@param moduleName string 代理模块名称
function _M.RegisterProxy(moduleName)
    log:Info("Register Proxy : ", moduleName)
    LuaModel.RegisterProxy(moduleName)
end

---获取数据代理
---@param moduleName string 代理模块名称
---@param whetherToCreate boolean 如果不存在是否创建
---@return AbstractProxy 获取到的数据代理对象
function _M.GetProxy(moduleName, whetherToCreate)
    log:Info("Get Proxy : ", moduleName, " whetherToCreate : ", tostring(whetherToCreate))
    return LuaModel.GetProxy(moduleName, whetherToCreate)
end

---尝试获取代理
---@param moduleName string 代理模块名称
---@return boolean,AbstractProxy 是否获取到代理,如果成功返回数据代理对象
function _M.TryGetProxy(moduleName)
    log:Info("Try Get Proxy : ", moduleName)
    return LuaModel.TryGetProxy(moduleName)
end

---移除数据代理
---@param moduleName string 代理模块名称
---@return boolean 是否移除成功
function _M.RemoveProxy(moduleName)
    log:Info("Remove Proxy : ", moduleName)
    return LuaModel.RemoveProxy(moduleName)
end

---移除全部数据代理
function _M.RemoveAllProxy()
    log:Info("Remove All Proxy")
    LuaModel.RemoveAllProxy()
end

--endregion

--region ----------Mediator----------

---注册中介器
---@param moduleName string 中介器模块名称
---@param mediatorName string 中介器对象名称(可以传 nil,nil 时等于 moduleName)
---@return AbstractMediator 中介器对象
function _M.RegisterMediator(moduleName, mediatorName)
    log:Info("RegisterMediator : ", moduleName, " | ", tostring(mediatorName))
    return LuaView.RegisterMediator(moduleName, mediatorName)
end

---获取中介器
---@param mediatorName string 中介器对象名称
---@return AbstractMediator
function _M.GetMediator(mediatorName)
    log:Info("Get Mediator : ", mediatorName)
    return LuaView.GetMediator(mediatorName)
end

---中介器是否已经被注册过
---@param mediatorName string 中介器对象名称
---@return boolean
function _M.IsExistMediator(mediatorName)
    log:Info("Is Exist Mediator : ", mediatorName)
    return LuaView.IsExist(mediatorName)
end

---移除中介器
---@param mediatorName string 中介器对象名称
function _M.RemoveMediator(mediatorName)
    log:Info("Remove Mediator : ", mediatorName)
    LuaView.RemoveMediator(mediatorName)
end

--endregion

--region ----------Notify----------

---添加消息监听
---@param notifyCode NotifySystem.Code 消息号
---@param method NotifySystem.Function 通知事件
---@param centerName string 消息中心名称
function _M.AddListener(notifyCode, method, centerName)
    NotifySystem.AddListener(notifyCode, method, centerName)
end

---发送消息
---@param notifyCode NotifySystem.Code 消息号
---@param data table 消息所携带的数据
---@param centerName string 消息中心名称( nil 时,为 NotifySystem.CenterName.Name)
function _M.SendNotify(notifyCode, data, centerName)
    NotifySystem.Send(notifyCode, data, centerName)
end

---移除监听
---@param notifyCode NotifySystem.Code 消息号
---@param method NotifySystem.Function 通知事件
---@param centerName string 消息中心名称
function _M.RemoveListener(notifyCode, method, centerName)
    NotifySystem.RemoveListener(notifyCode, method, centerName)
end

---移除指定 Block 下的所有监听
---@param Block string 消息 Block
---@param centerName string 消息中心名称
function _M.RemoveListenerForBlock(Block, centerName)
    NotifySystem.RemoveListenerForBlock(Block, centerName)
end

---移除指定消息 Code 下的所有监听
---@param notifyCode NotifySystem.Code 消息号
---@param centerName string 消息中心名称
function _M.RemoveListenerForCode(notifyCode, centerName)
    NotifySystem.RemoveListenerForCode(notifyCode, centerName)
end

---清除指定消息中心内的所有监听
---@param centerName string 消息中心名称
function _M.RemoveAllListener(centerName)
    NotifySystem.RemoveAllListener(centerName)
end

--endregion

---清理释放
function _M.ClearApp()
    LuaModel.RemoveAllProxy()
    LuaController.RemoveAllCommands()
    LuaView.RemoveAllMediator()

    NotifySystem.ClearAll()
end

return _M