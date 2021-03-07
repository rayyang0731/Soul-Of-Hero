---
--- AbstractProxy
---

---@class AbstractProxy
---@field name string 代理标签名称
---@field Facade LuaFacade Lua 外观角色
local _M = { _VERSION = "1.0" }
local mt = { __index = _M }
local log = Log.Create("AbstractProxy")
----------------------------------------------------------------------------------

--region ----------构造函数----------

---@param tag string 代理标签名称
---@return AbstractProxy
function _M:new(tag)
    return setmetatable({ name = tag, Facade = LuaFacade }, mt)
end

--endregion

--region ----------公共方法----------

---注册时调用
function _M:OnRegister()
    log:Info("Proxy 基类,不应该调用到此类的方法,请检查[", self.name, "]指令模块")
end

---移除时调用
function _M:OnRemove()
    log:Info("Proxy 基类,不应该调用到此类的方法,请检查[", self.name, "]指令模块")
end

--endregion

return _M