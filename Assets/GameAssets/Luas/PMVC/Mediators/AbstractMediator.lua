---
--- AbstractMediator
---

---@class AbstractMediator
---@field name string 代理标签名称
---@field Facade LuaFacade Lua 外观角色
local _M = { _VERSION = "1.0" }

local log = Log.Create("AbstractMediator")
----------------------------------------------------------------------------------

--region ----------构造函数----------

---@param tag string 代理标签名称
function _M:new(tag)
    ---@type AbstractProxy
    local abstractProxy = require("AbstractProxy"):new("AbstractMediator")
    return setmetatable({ name = tag, Facade = LuaFacade }, { __index = abstractProxy })
end

--endregion

--region ----------监听模块----------

--local Observe = {}
--local _ot = { __index = Observe }
--
--function Observe:new(msg,)
--    
--end

--endregion

--region ----------私有方法----------



--endregion

--region ----------公共方法----------

---注册时调用
function _M:OnRegister()

end

---移除时调用
function _M:OnRemove()

end

--endregion

return _M