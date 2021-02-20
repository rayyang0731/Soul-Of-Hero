namespace KiwiFramework.Core
{
    /// <summary>
    /// 应用外观
    /// </summary>
    public class AppFacade : Facade<AppFacade>
    {
        public void Startup()
        {
            RegisterCommand<StartupCommand>(CMD_TAG.STARTUP);
            SendNotify(CMD_TAG.STARTUP);
        }
    }
}