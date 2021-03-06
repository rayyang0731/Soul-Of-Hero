---
--- NotifySystem
---

---@class NotifySystem
local _M = { _VERSION = "1.0" }

---@type NotifyCenter
local NotifyCenter = require("NotifyCenter")

local log = Log.Create("NotifySystem")
----------------------------------------------------------------------------------

local CenterName = { Main = "Main" }

---@type table<string,NotifyCenter>
local centerMap = {
    Main = NotifyCenter:new(CenterName.Main)
}

---添加消息通知中心
---@param centerName string 通知中心名称
function _M.AddNotifyCenter(centerName)
    CenterName = CenterName or {}
    CenterName[centerName] = centerName
    centerMap = centerMap or {}
    centerMap[centerName] = NotifyCenter:new(CenterName[centerName])
end

---获取通知中心
---@param centerName string 中心名称
---@return NotifyCenter
local function GetNotifyCenter(centerName)
    if centerName == nil then
        centerName = CenterName.Main
    end
    return centerMap[centerName]
end

---发送通知
---@param notifyCode NotifySystem.Code 消息号
---@param data table 消息所携带的数据
---@param centerName string 消息中心名称
function _M.Send(notifyCode, data, centerName)
    GetNotifyCenter(centerName):Send(notifyCode, data)
end

---添加监听
---@param notifyCode NotifySystem.Code 消息号
---@param method NotifySystem.Function 通知事件
---@param centerName string 消息中心名称
function _M.AddListener(notifyCode, method, centerName)
    GetNotifyCenter(centerName):Listen(notifyCode, method)
end

---移除监听
---@param notifyCode NotifySystem.Code 消息号
---@param method NotifySystem.Function 通知事件
---@param centerName string 消息中心名称
function _M.RemoveListener(notifyCode, method, centerName)
    GetNotifyCenter(centerName):RemoveListen(notifyCode, method)
end

---移除指定 Block 下的所有监听
---@param Block string 消息 Block
---@param centerName string 消息中心名称
function _M.RemoveListenerForBlock(Block, centerName)
    GetNotifyCenter(centerName):RemoveListenForBlock(Block)
end

---移除指定消息 Code 下的所有监听
---@param notifyCode NotifySystem.Code 消息号
---@param centerName string 消息中心名称
function _M.RemoveListenerForCode(notifyCode, centerName)
    GetNotifyCenter(centerName):RemoveListenForCode(notifyCode)
end

---清除指定消息中心内的所有监听
---@param centerName string 消息中心名称
function _M.RemoveAllListener(centerName)
    GetNotifyCenter(centerName):ClearAll()
end

---清除所有通知中心的所有监听
function _M.ClearAll()
    for _, center in pairs(centerMap) do
        center:ClearAll()
    end
end

return _M