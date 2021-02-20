using UnityEngine;

namespace KiwiFramework.Core
{
    /// <summary>
    /// Mono单例
    /// </summary>
    /// <typeparam name="T">单例类型,必须继承 MonoBehaviour</typeparam>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance = null;
        private static bool _applicationIsQuit = false;

        public static T Instance
        {
            get
            {
                if (_instance == null && !_applicationIsQuit)
                    Initialize();
                return _instance;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>单例对象</returns>
        private static T Initialize()
        {
            _instance = FindObjectOfType<T>();

            if (_instance != null)
            {
                // Log.WarningFormat("[{0}]单例已经存在,不应重新创建,请检查出现此问题的原因.", _instance.ToString());
                return _instance;
            }

            var instanceName = typeof(T).Name;
            var instanceGo = GameObject.Find(instanceName);

            if (instanceGo == null)
                instanceGo = new GameObject($"[{instanceName}]");

            _instance = instanceGo.AddComponent<T>();
            DontDestroyOnLoad(instanceGo); //保证实例不会被释放
            // Log.InfoFormat("添加一个新的单例:{0}", instanceName);
            return _instance;
        }

        protected virtual void Awake()
        {
            if (_instance != null) return;

            GameObject o;
            _instance = (o = gameObject).GetComponent<T>();
            DontDestroyOnLoad(o);
        }

        protected virtual void OnApplicationQuit()
        {
            if (_instance == null)
                return;
            Destroy(_instance.gameObject);
            _instance = null;
        }

        protected virtual void OnDestroy()
        {
            _applicationIsQuit = true;
        }
    }
}