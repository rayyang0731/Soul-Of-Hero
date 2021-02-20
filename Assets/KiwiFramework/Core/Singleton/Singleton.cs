namespace KiwiFramework.Core
{
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static T _instance = null;
        
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                _instance = System.Activator.CreateInstance(typeof(T), true) as T;
                if (_instance == null)
                    throw new System.Exception("创建单例失败");
                KiwiLog.InfoFormat("添加一个新的单例:{0}", typeof(T).Name);

                return _instance;
            }
        }
    }
}