---
--- LuaView
---

---@class LuaView
local _M = { _VERSION = "1.0" }

local log = Log.Create("LuaView")
----------------------------------------------------------------------------------

---中介器Map [k - 中介器对象名称, v - 中介器对象 ]
---@type table<string,AbstractMediator>
local mediatorMap = {}

---注册中介器
---@param moduleName string 中介器模块名称
---@param mediatorName string 中介器对象名称
---@return AbstractMediator 中介器对象
function _M.RegisterMediator(moduleName, mediatorName)
    if mediatorName == nil then
        mediatorName = moduleName
    end
    if mediatorMap[mediatorName] ~= nil then
        log:Warn("要注册已经存在的中介器 : ", mediatorName, ",请确认是否是正常操作.")
        mediatorMap[mediatorName]:OnRemove()
        mediatorMap[mediatorName] = nil
    end
    mediatorMap[mediatorName] = require(moduleName):new(mediatorName)
    return mediatorMap[mediatorName]
end

---获取中介器
---@param mediatorName string 中介器对象名称
---@return AbstractMediator 指定名称的中介器对象
function _M.GetMediator(mediatorName)
    return mediatorMap[mediatorName]
end

---中介器是否被注册
---@param mediatorName string 中介器对象名称
---@return boolean
function _M.IsExist(mediatorName)
    return mediatorMap[mediatorName] ~= nil
end

---移除中介器
---@param mediatorName string 中介器模块名称
function _M.RemoveMediator(mediatorName)
    if not _M.IsExist(mediatorName) then
        return
    end

    mediatorMap[mediatorName]:OnRemove()
    mediatorMap[mediatorName] = nil
end

---移除全部中介器
function _M.RemoveAllMediator()
    for _, mediator in pairs(mediatorMap) do
        mediator:OnRemove()
    end
    mediatorMap = nil
    mediatorMap = {}
end

return _M