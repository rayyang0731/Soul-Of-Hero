---
--- LoginCommand
---

---@class LoginCommand
---@field name string 指令标签名称
local _M = { _VERSION = "1.0" }

local log = Log.Create("LoginCommand")
----------------------------------------------------------------------------------

--region ----------构造函数----------

function _M:new()
    ---@type AbstractCommand
    local abstractCommand = require("AbstractCommand"):new("LoginCommand")
    return setmetatable(_M, { __index = abstractCommand })
end

--endregion

--region ----------公共方法----------

---执行指令
---@param data table 数据
function _M:Execute(data)
    SceneManager.LoadScene("Login", LoadSceneMode.Additive)
    --ViewManager.Instance:OpenView("UILoginView")
end

--endregion

return _M