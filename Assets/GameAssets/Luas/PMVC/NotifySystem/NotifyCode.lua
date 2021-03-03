---
--- NotifyCode
---

---@alias NotifySystem.Code {Block:string,Code:string}

local NotifyCode = {}

local NotifyBlock = {
    COMMON = "COMMON",
    LOGIN = "LOGIN",
}

--region ----------COMMON----------

---游戏启动

---@type NotifySystem.Code
NotifyCode.STARTUP = { Block = NotifyBlock.COMMON, Code = "CMD.STARTUP" }

--endregion

--region ----------LOGIN----------

---登陆
---@type NotifySystem.Code
NotifyCode.LOGIN = { Block = NotifyBlock.LOGIN, Code = "CMD.LOGIN" }
---账号注册
---@type NotifySystem.Code
NotifyCode.ACCOUNT_SIGN_UP = { Block = NotifyBlock.LOGIN, Code = "CMD.ACCOUNT_SIGN_UP" }
---账号登陆
---@type NotifySystem.Code
NotifyCode.ACCOUNT_SIGN_IN = { Block = NotifyBlock.LOGIN, Code = "CMD.ACCOUNT_SIGN_IN" }
---登陆成功
---@type NotifySystem.Code
NotifyCode.SIGN_IN_SUCCESSFUL = { Block = NotifyBlock.LOGIN, Code = "CMD.SIGN_IN_SUCCESSFUL" }

--endregion


return NotifyCode