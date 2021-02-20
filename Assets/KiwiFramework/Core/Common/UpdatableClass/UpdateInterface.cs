namespace KiwiFramework.Core
{
    public interface IFixedUpdate
    {
        int FixedUpdateOrder { get; }
        void OnFixedUpdate();
    }

    public interface IUpdate
    {
        int UpdateOrder { get; }
        void OnUpdate();
    }

    public interface ILateUpdate
    {
        int LateUpdateOrder { get; }
        void OnLateUpdate();
    }
}