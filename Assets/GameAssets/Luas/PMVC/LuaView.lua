---
--- LuaView
---

---@class LuaView
local _M = { _VERSION = "1.0" }

local log = Log.Create("LuaView")
----------------------------------------------------------------------------------

---中介器Map [k - 中介器标签, v - 中介器对象 ]
---@type table<string,AbstractMediator>
local mediatorMap = {}

---注册中介器
---@param moduleName string 中介器模块名称
function _M.RegisterMediator(moduleName)
    mediatorMap[moduleName] = require(moduleName)
end

---获取中介器
---@param moduleName string 中介器模块名称
function _M.GetMediator(moduleName)
    return mediatorMap[moduleName]
end

---移除中介器
---@param moduleName string 中介器模块名称
function _M.RemoveMediator(moduleName)
    
end

return _M