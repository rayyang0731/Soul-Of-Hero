using System;
using KiwiFramework;
using KiwiFramework.Core;

namespace KiwiFramework.Example
{
    public class UpdatableExample_Update : BaseMonoBehaviour, IUpdate, IFixedUpdate, ILateUpdate
    {
        public int uorder;
        public int fuorder;
        public int luorder;

        public int UpdateOrder
        {
            get { return uorder; }
        }

        public void OnUpdate()
        {
        }

        public int FixedUpdateOrder
        {
            get { return fuorder; }
        }

        public void OnFixedUpdate()
        {
        }

        public int LateUpdateOrder
        {
            get { return luorder; }
        }

        public void OnLateUpdate()
        {
        }
    }
}