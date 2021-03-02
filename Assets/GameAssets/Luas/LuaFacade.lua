---
--- LuaFacade.lua
---

---@class LuaFacade
local _M = { _VERSION = "1.0" }

---@type LuaController
local LuaController = require("LuaController")

local log = Log.Create("LuaFacade")
----------------------------------------------------------------------------------

---注册指令
---@param commandTag string 指令标签
---@param moduleName string 指令模块名称
function _M:RegisterCommand(commandTag, moduleName)
    log:Info("Register command : ", commandTag, " | ", moduleName)
    LuaController.RegisterCommand(commandTag, moduleName)
end

---执行指令
---@param commandTag string 指令标签
---@param data table 数据
function _M:ExecuteCommand(commandTag, data)
    log:Info("Execute command : ", commandTag)
    LuaController.ExecuteCommand(commandTag, data)
end

return _M