namespace KiwiFramework.Core
{
    /// <summary>
    /// 可更新基类
    /// </summary>
    public abstract class BaseUpdatableClass
    {
        /// <summary>
        /// 顺序
        /// </summary>
        public virtual int Order
        {
            get { return 0; }
        }

        public BaseUpdatableClass()
        {
            UpdateManager.Instance.Add(this);
        }

        ~BaseUpdatableClass()
        {
            if (UpdateManager.Instance)
                UpdateManager.Instance.Remove(this);
        }
    }
}