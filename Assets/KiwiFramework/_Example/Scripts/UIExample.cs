using KiwiFramework.Core;
using UnityEngine;

namespace KiwiFramework.Example
{
    public class UIExample : MonoBehaviour
    {
        void Start()
        {
            ViewManager.Instance.OpenView("UITestView");
        }
    }
}