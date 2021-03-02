---
--- LuaModel
---

---@class LuaModel
local _M = { _VERSION = "1.0" }

local log = Log.Create("LuaModel")
----------------------------------------------------------------------------------

---代理Map [k - 代理标签, v - 代理对象 ]
---@type table<string,AbstractProxy>
local proxyMap = {}

---注册数据代理
---@param moduleName string 代理模块名称
function _M.RegisterProxy(moduleName)
    proxyMap[moduleName] = require(moduleName):new(moduleName)
    proxyMap[moduleName]:OnRegister()
end

---获取数据代理
---@param moduleName string 代理模块名称
---@param whetherToCreate boolean 如果不存在是否创建
---@return AbstractProxy 获取到的数据代理对象
function _M.GetProxy(moduleName, whetherToCreate)
    local result = proxyMap[moduleName]
    if result == nil and whetherToCreate then
        _M.RegisterProxy(moduleName)
        result = proxyMap[moduleName]
    end
    return result
end

---尝试获取代理
---@param moduleName string 代理模块名称
---@return boolean,AbstractProxy 是否获取到代理,如果成功返回数据代理对象
function _M.TryGetProxy(moduleName)
    local proxy = proxyMap[moduleName]
    local contains = proxy ~= nil
    return contains, proxy
end

---移除数据代理
---@param moduleName string 代理模块名称
---@return boolean 是否移除成功
function _M.RemoveProxy(moduleName)
    if proxyMap[moduleName] ~= nil then
        proxyMap[moduleName]:OnRemove()
        proxyMap[moduleName] = nil;
        return true
    end
    return false
end

---移除全部数据代理
function _M.RemoveAllProxy()
    for _, v in pairs(proxyMap) do
        v:OnRemove()
    end

    proxyMap = nil
    proxyMap = {}
end

return _M