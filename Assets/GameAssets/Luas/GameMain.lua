Log = require("Log")
LuaFacade = require("LuaFacade")

--if CS.KiwiFramework.Core.ProjectIniSetting.GetInt("Game", "Develop") == 1 then
--region ----------EmmyLua Remote Debugger----------

--package.cpath = package.cpath .. ';/Users/rayyang/Documents/Git/Soul Of Hero/Assets/Plugins 3rd/EmmyLua/Editor/emmy_core.dylib'
--local dbg = require('emmy_core')
--dbg.tcpListen('localhost', 9966)

--endregion
--end

LuaFacade:RegisterCommand("Startup", "StartupCommand")
LuaFacade:ExecuteCommand("Startup", { msg = "Test Msg" })
--LuaFacade: