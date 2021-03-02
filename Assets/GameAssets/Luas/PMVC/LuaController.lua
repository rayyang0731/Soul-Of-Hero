---
--- LuaController
---

---@class LuaController
local _M = { _VERSION = "1.0" }

local log = Log.Create("LuaController")
----------------------------------------------------------------------------------

---指令Map [k - 指令模块名称, v - 指令对象 ]
---@type table<string,AbstractCommand>
local commandMap = {}

---注册指令
---@param moduleName string 指令模块名称
function _M.RegisterCommand(moduleName)
    commandMap[moduleName] = require(moduleName):new(moduleName)
end

---执行指令
---@param moduleName string 指令模块名称
---@param data table 消息数据
function _M.ExecuteCommand(moduleName, data)
    if commandMap[moduleName] ~= nil then
        commandMap[moduleName]:Execute(data)
    end
end

---移除指令
---@param moduleName string 指令模块名称
function _M.RemoveCommand(moduleName)
    if commandMap[moduleName] ~= nil then
        commandMap[moduleName] = nil
    end
end

---移除全部指令
function _M.RemoveAllCommands()
    commandMap = nil
    commandMap = {}
end

return _M