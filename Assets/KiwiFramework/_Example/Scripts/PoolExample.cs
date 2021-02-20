using System.Collections;
using System.Collections.Generic;
using KiwiFramework.Core;
using UnityEngine;

namespace KiwiFramework.Example
{
    public class PoolExample : MonoBehaviour
    {
        public GameObject Sphere;
        public GameObject Cube;
        public GameObject Capsule;

        private void Start()
        {
            PoolManager.Instance.AddLoadInfo(Sphere, 10, true, "NoCapsule");
            PoolManager.Instance.AddLoadInfo(Cube, 10, true, "NoCapsule");
            PoolManager.Instance.AddLoadInfo(Capsule, 10, true);
            PoolManager.Instance.StartLoadAllInfos();
        }

        private void OnGUI()
        {
            if (GUILayout.Button(PoolManager.Instance.HasPool("Sphere")
                ? "Active Object(Sphere)"
                : "Create Pool(Sphere)"))
            {
                UnityObjectPool pool;
                var gotIt = PoolManager.Instance.TryGetPool("Sphere", out pool);
                if (gotIt)
                {
                    GameObject go = pool.Get();
                    go.SetActive(true);
                }
                else
                {
                    PoolManager.Instance.StartLoad(Sphere, 10, true, "NoCapsule");
                }
            }

            if (GUILayout.Button(PoolManager.Instance.HasPool("Cube")
                ? "Active Object(Cube)"
                : "Create Pool(Cube)"))
            {
                UnityObjectPool pool;
                var gotIt = PoolManager.Instance.TryGetPool("Cube", out pool);
                if (gotIt)
                {
                    GameObject go = pool.Get();
                    go.SetActive(true);
                    Timer.Startup(3, (t) => { pool.Recycle(go); });
                }
                else
                {
                    PoolManager.Instance.StartLoad(Cube, 10, true, "NoCapsule");
                }
            }

            if (GUILayout.Button(PoolManager.Instance.HasPool("Capsule")
                ? "Active Object(Capsule)"
                : "Create Pool(Capsule)"))
            {
                UnityObjectPool pool;
                var gotIt = PoolManager.Instance.TryGetPool("Capsule", out pool);
                if (gotIt)
                {
                    GameObject go = pool.Get();
                    go.SetActive(true);
                    go.GetComponent<UnityObjectPoolSign>().RecycleDelay(3);
                }
                else
                {
                    PoolManager.Instance.StartLoad(Capsule, 10, true);
                }
            }

            if (GUILayout.Button("Release Pool(Group:NoCapsule)"))
            {
                PoolManager.Instance.ReleasePoolsByGroup("NoCapsule", true);
            }

            if (GUILayout.Button("Release Pool(Group:Default)"))
            {
                PoolManager.Instance.ReleasePoolsByDefaultGroup();
            }
        }

        private void OnDestroy()
        {
            PoolManager.Instance.ReleaseAllPools();
        }
    }
}