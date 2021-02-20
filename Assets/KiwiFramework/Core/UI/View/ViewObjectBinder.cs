using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KiwiFramework.UI
{
    [Serializable]
    public class ViewObjectBinder
    {
        /// <summary>
        /// 界面所用的所有对象
        /// </summary>
        [LabelText("界面 UI 对象"), SerializeField,
         ListDrawerSettings(HideAddButton = true, HideRemoveButton = true, Expanded = true, ShowPaging = true,
             NumberOfItemsPerPage = 10, DraggableItems = false, IsReadOnly = true), PropertyOrder(2), ReadOnly]
        private List<Object> allObjects = new List<Object>();

#if UNITY_EDITOR
        /// <summary>
        /// 对象数量
        /// </summary>
        [HideInInspector]
        public int ObjectCount => allObjects.Count;
#endif

        public void Add(Object obj)
        {
            allObjects.Add(obj);
        }

        public Object Get(int index)
        {
            return index < allObjects.Count ? allObjects[index] : null;
        }
    }
}