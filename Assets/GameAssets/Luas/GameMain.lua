require("CSDefine")

_G["Log"] = require("Log")
_G["CommandTag"] = require("CommandTag")
_G["LuaFacade"] = require("LuaFacade")

--if CS.KiwiFramework.Core.ProjectIniSetting.GetInt("Game", "Develop") == 1 then
--region ----------EmmyLua Remote Debugger----------

--package.cpath = package.cpath .. ';/Users/rayyang/Documents/Git/Soul Of Hero/Assets/Plugins 3rd/EmmyLua/Editor/emmy_core.dylib'
--local dbg = require('emmy_core')
--dbg.tcpListen('localhost', 9966)

--endregion
--end


LuaFacade.RegisterCommand(CommandTag.STARTUP)
LuaFacade.ExecuteCommand(CommandTag.STARTUP)
