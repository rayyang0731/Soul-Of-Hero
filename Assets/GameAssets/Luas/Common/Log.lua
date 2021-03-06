---
--- Log
---

---@class Log
local _M = { _VERSION = "1.0" }

----------------------------------------------------------------------------------

---Log 等级定义
local LOG_LEVEL = {
    DEBUG = 0,
    INFO = 1,
    WARN = 2,
    ERROR = 3,
    EXCEPTION = 4,
}

---@class Log.log
local log = { name = "UNKNOWN" }

---@type Log.log[]
local logMap = {}

---是否启用 Log
local LogEnabled = true

--region ----------私有方法----------

---获得 Log 等级名称
---@param level number Log 等级
local function GetLevelName(level)
    if level == LOG_LEVEL.DEBUG then
        return "<B>[DEBUG]</B>"
    elseif level == LOG_LEVEL.INFO then
        return "[INFO]"
    elseif level == LOG_LEVEL.WARN then
        return "[WARN]"
    elseif level == LOG_LEVEL.ERROR then
        return "[ERROR]"
    elseif level == LOG_LEVEL.EXCEPTION then
        return "[EXCEPTION]"
    end

    return "[UNKNOWN]"
end

---获取 Log 方法
---@param level number
---@return function 要调用的方法
local function GetLogFunc(level)
    if level == LOG_LEVEL.DEBUG then
        return KiwiLog.Info
    elseif level == LOG_LEVEL.INFO then
        return KiwiLog.Info
    elseif level == LOG_LEVEL.WARN then
        return KiwiLog.Warning
    elseif level == LOG_LEVEL.ERROR then
        return KiwiLog.Error
    elseif level == LOG_LEVEL.EXCEPTION then
        return KiwiLog.Exception
    end

    return KiwiLog.Info
end

local function list_table(tab, table_list, layer, showMetatable)
    local result = ""
    local indent = string.rep(" ", layer * 4)

    for k, v in pairs(tab) do
        local mark = type(k) == "string" and '"' or ""
        result = result .. indent .. "[" .. mark .. tostring(k) .. mark .. "] = "

        if type(v) == "table" then
            local tableName = table_list[v]
            if tableName then
                result = result .. tostring(v) .. " -- > [\"" .. tableName .. "\"]\n"
            else
                table_list[v] = tostring(k)
                result = result .. "{\n"
                result = result .. list_table(v, table_list, layer + 1, showMetatable)
                result = result .. indent .. "\n}\n"
            end
        elseif type(v) == "string" then
            result = result .. "\"" .. tostring(v) .. "\"\n"
        else
            result = result .. tostring(v) .. "\n"
        end
    end

    if showMetatable then
        local metaTable = getmetatable(tab)
        if metaTable then
            result = result .. "\n"
            local tableName = table_list[metaTable]
            result = result .. indent .. "<metatable> = "

            if tableName then
                result = result .. tostring(metaTable) .. " -- > [\"" .. tableName .. "\"]\n"
            else
                result = result .. "{\n"
                result = result .. list_table(metaTable, table_list, layer + 1, showMetatable)
                result = result .. indent .. "}\n"
            end
        end
    end

    return result
end

local function table_tostring(tab, showMetatable)
    if type(tab) ~= "table" then
        KiwiLog.Error("要打印的对象不是 table 类型,类型为", type(tab), ".")
        return ""
    end

    local result = "{\n"
    local table_list = {}
    table_list[tab] = "root table"
    result = result .. list_table(tab, table_list, 1, showMetatable)
    result = result .. "\n}"
    return result
end

---打印
---@param modName string 模块名称
---@param logLevel number Log 等级
---@vararg string
local function Print(modName, logLevel, ...)
    if not LogEnabled then
        return
    end

    local content = {
        GetLevelName(logLevel),
        "[", modName, ":", debug.getinfo(3).currentline, "] >>> "
    }
    local args = { ... }
    for i = 1, #args do
        table.insert(content, tostring(args[i]))
    end

    table.insert(content, "\n")

    if logLevel >= LOG_LEVEL.DEBUG then
        table.insert(content, debug.traceback())
    end

    if type(modName) == "table" then
        KiwiLog.Info(table_tostring(modName))
        return
    end

    local msg = table.concat(content, "")
    GetLogFunc(logLevel)(msg)
end

--endregion

--region ----------公共方法----------

---创建 log 对象
---@param moduleName string 模块名称
---@return Log.log
function _M.Create(moduleName)
    if type(moduleName) ~= "string" then
        Print("Log Error", LOG_LEVEL.ERROR, "moduleName is not string.")
        moduleName = "UNKNOWN"
    end

    if logMap[moduleName] ~= nil then
        return logMap[moduleName]
    end

    logMap[moduleName] = setmetatable({ name = moduleName }, { __index = log })
    return logMap[moduleName]
end

---设置 Log 是否可用
---@param enable boolean Log 是否可用
function _M.SetEnable(enable)
    if enable then
        KiwiLog.LogEnabled = true
        KiwiLog.Info("<color=yellow>打开日志</color>")
    else
        KiwiLog.Info("<color=yellow>关闭日志</color>")
        KiwiLog.LogEnabled = false
    end

    LogEnabled = enable
end

function log:Debug(...)
    Print(self.name, LOG_LEVEL.DEBUG, ...)
end

function log:Info(...)
    Print(self.name, LOG_LEVEL.INFO, ...)
end

function log:Warn(...)
    Print(self.name, LOG_LEVEL.WARN, ...)
end

function log:Error(...)
    Print(self.name, LOG_LEVEL.ERROR, ...)
end

function log:Exception(...)
    Print(self.name, LOG_LEVEL.EXCEPTION, ...)
end

function log:PrintTable(tab)
    Print(tab, LOG_LEVEL.DEBUG)
end
--endregion

return _M