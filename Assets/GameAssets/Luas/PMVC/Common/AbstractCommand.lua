---
--- AbstractCommand
---

---@class AbstractCommand
---@field name string 指令标签名称
local _M = { _VERSION = "1.0" }
local mt = { __index = _M }
local log = Log.Create("AbstractCommand")
----------------------------------------------------------------------------------

--region ----------构造函数----------

---@param tag string 指令标签名称
function _M:new(tag)
    return setmetatable({ name = tag }, mt)
end

--endregion

--region ----------公共方法----------

---执行指令
---@param data table 数据
function _M:Execute(data)
    log:Info("Command 基类,不应该调用到此类的方法,指令名称为 : ", self.name)
end

--endregion

return _M