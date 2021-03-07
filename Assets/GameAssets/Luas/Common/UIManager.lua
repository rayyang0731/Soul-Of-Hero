---
--- UIManager
---

---@class UIManager
local _M = { _VERSION = "1.0" }

local log = Log.Create("UIManager")
----------------------------------------------------------------------------------

---@type table<string,LuaBaseView>
local viewMap = {}

---打开界面
---@param viewName string 界面名称(必须是界面 LuaTable 的名字)
---@param viewAlias string 界面别名(可以传 nil,nil 时等于 viewName)
function _M.OpenView(viewName, viewAlias)
    if viewAlias == nil then
        viewAlias = viewName
    end
    ---@type LuaBaseView
    local viewLuaTable = require(viewName):new(viewAlias)
    ---@type KiwiFramework.Core.XLuaModule.LuaViewBehaviour
    local view = ViewManager:OpenViewLua(viewName, viewAlias)
    view:Bind(viewName, viewLuaTable)

    viewMap[viewAlias] = viewLuaTable
end

---关闭界面
---@param viewName string 界面名称
function _M.CloseView(viewName)
    if _M.GetView(viewName) ~= nil then
        return
    end
    ViewManager:CloseView(viewName)
    viewMap[viewName] = nil
end

---获取界面
---@param viewName string 界面名称
---@return LuaBaseView
function _M.GetView(viewName)
    return viewMap[viewName]
end

return _M