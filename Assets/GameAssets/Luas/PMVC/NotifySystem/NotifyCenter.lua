---
--- NotifyCenter
---

---@alias NotifySystem.Function fun(data:table):void

---@class NotifyCenter
local _M = { _VERSION = "1.0" }
local mt = { __index = _M }

_G["NotifyCode"] = require("NotifyCode")

local log = Log.Create("NotifyCenter")
----------------------------------------------------------------------------------

function _M:new(name)
    return setmetatable({ name = name }, mt)
end

---@type table<string,table<string,NotifySystem.Function[]>>
local notifyMap = {}

---检测消息号的有效性
---@param notifyCode NotifySystem.Code 消息号
---@return boolean 消息号是否有效
local function IsNotifyCodeValid(notifyCode)
    if notifyCode == nil then
        log:Error("消息号有错误,notifyCode 为 nil.")
        return false
    end
    if type(notifyCode.Block) ~= "string" or type(notifyCode.Block) == "" then
        log:Error("消息号 Block 类型不为 string 或为 string.Empty")
        return false
    end
    if type(notifyCode.Code) ~= "string" or type(notifyCode.Code) == "" then
        log:Error("消息号 Code 类型不为 string 或为 string.Empty")
        return false
    end
    return true
end

---@return number 当前广播数量
function _M:Count()
    local count = 0
    for _, _ in pairs(notifyMap) do
        count = count + 1
    end
    return count
end

---监听消息
---@param notifyCode NotifySystem.Code 消息号
---@param method NotifySystem.Function 通知事件
function _M:Listen(notifyCode, method)
    if not IsNotifyCodeValid(notifyCode) then
        return
    end
    if type(method) ~= "function" then
        log:Error("method 不为 function 类型")
        return
    end

    notifyMap[notifyCode.Block] = notifyMap[notifyCode.Block] or {}
    notifyMap[notifyCode.Block][notifyCode.Code] = notifyMap[notifyCode.Block][notifyCode.Code] or {}
    table.insert(notifyMap[notifyCode.Block][notifyCode.Code], method)
end

---移除消息监听
---@param notifyCode NotifySystem.Code 消息号
---@param method NotifySystem.Function 通知事件
function _M:RemoveListen(notifyCode, method)
    if not IsNotifyCodeValid(notifyCode) then
        return
    end
    if type(method) ~= "function" then
        log:Error("method 不为 function 类型")
        return
    end

    if notifyMap[notifyCode.Block] == nil then
        return
    end

    local wannaRemoveIndex = -1
    local methods = notifyMap[notifyCode.Block][notifyCode.Code]
    for i, v in ipairs(methods) do
        if v == method then
            wannaRemoveIndex = i
            break
        end
    end
    if wannaRemoveIndex > 0 then
        table.remove(methods, wannaRemoveIndex)
    end
end

---移除指定 Block 下的所有监听
---@param Block string 消息 Block
function _M:RemoveListenForBlock(Block)
    notifyMap[Block] = nil
end

---移除指定消息 Code 下的所有监听
---@param notifyCode NotifySystem.Code 消息号
function _M:RemoveListenForCode(notifyCode)
    notifyMap[notifyCode.Block][notifyCode.Code] = nil
end

---发送消息
---@param notifyCode NotifySystem.Code 消息号
---@param data table 消息所携带的数据
function _M:Send(notifyCode, data)
    if not IsNotifyCodeValid(notifyCode) then
        return
    end
    local methods = notifyMap[notifyCode.Block][notifyCode.Code]
    if methods ~= nil then
        for i = 1, #methods do
            methods[i](data)
        end
    end
end

---清除所有监听
function _M:ClearAll()
    notifyMap = nil
    notifyMap = {}
end

return _M