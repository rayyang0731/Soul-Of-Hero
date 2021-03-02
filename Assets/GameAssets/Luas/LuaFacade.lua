---
--- LuaFacade.lua
---

---@class LuaFacade
local _M = { _VERSION = "1.0" }

---@type LuaController
local LuaController = require("LuaController")
---@type LuaModel
local LuaModel = require("LuaModel")

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

function _M.RegisterMediator(moduleName)
    
end

--endregion

return _M