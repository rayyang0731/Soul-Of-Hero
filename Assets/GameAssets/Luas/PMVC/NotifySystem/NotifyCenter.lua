---
--- NotifyCenter
---

---@alias NotifySystem.Function fun(data:table):void

---@class NotifyCenter
local _M = { _VERSION = "1.0" }

_G["NotifyCode"] = require("NotifyCode")

local log = Log.Create("NotifyCenter")
----------------------------------------------------------------------------------

---@type table<string,table<string,NotifySystem.Function[]>>
local notifyMap = {}

---@return number 当前广播数量
function _M.Count()
    local count = 0
    for _, _ in pairs(notifyMap) do
        count = count + 1
    end
    return count
end

---监听消息
---@param notifyCode NotifySystem.Code 消息号
---@param method NotifySystem.Function 通知事件
function _M.Listen(notifyCode, method)
    notifyMap[notifyCode.Block] = notifyMap[notifyCode.Block] or {}
    notifyMap[notifyCode.Block][notifyCode.Code] = notifyMap[notifyCode.Block][notifyCode.Code] or {}
    table.insert(notifyMap[notifyCode.Block][notifyCode.Code], method)
end

function _M.RemoveListen(notify)

end

return _M