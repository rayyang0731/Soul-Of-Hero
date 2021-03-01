---
--- LuaController
---

---@class LuaController
local _M = { _VERSION = "1.0" }

local log = Log.Create("LuaController")
----------------------------------------------------------------------------------

---指令Map [k - 指令标签, v - 指令对象 
---@type table<string,AbstractCommand>
local commandMap = {}

---注册指令
---@param tag string 指令标签
---@param moduleName string 模块名称
function _M.RegisterCommand(tag, moduleName)
    commandMap[tag] = require(moduleName):new(tag)
end

---执行指令
---@param tag string 指令标签
---@param data table 消息数据
function _M.ExecuteCommand(tag, data)
    if commandMap[tag] ~= nil then
        commandMap[tag]:Execute(data)
    end
end

return _M