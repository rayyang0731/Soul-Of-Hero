using UnityEngine;

namespace KiwiFramework.Core
{
    public abstract class BaseAssetLoader
    {
        public abstract T Load<T>(string name) where T : Object;
    }
}