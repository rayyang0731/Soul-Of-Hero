using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KiwiFramework.UI
{
    /// <summary>
    /// UI音效类(点击音效控制)
    /// </summary>
    [Serializable]
    public class UISoundHelper
    {
        /// <summary>
        /// 音效描述
        /// </summary>
        [Serializable]
        private struct SoundDesc
        {
            /// <summary>
            /// 点击类型
            /// </summary>
            public POINTER_TYPE pointerType;

            /// <summary>
            /// 音效资源名称
            /// </summary>
            public string name;

            public SoundDesc(POINTER_TYPE pointerType, string name)
            {
                this.pointerType = pointerType;
                this.name = name;
            }
        }

        /// <summary>
        /// 是否静音
        /// </summary>
        [ShowInInspector, ReadOnly, DisplayAsString, LabelText("是否静音"), SuffixLabel("static")]
        public static bool Mute = false;

#if UNITY_EDITOR
        [ShowInInspector, LabelText("点击类型"), BoxGroup("Add", GroupName = "添加音效数据", CenterLabel = true)]
        private POINTER_TYPE addType = POINTER_TYPE.DOWN;

        [ShowInInspector, LabelText("资源名称"), BoxGroup("Add")]
        private string addName = string.Empty;

        [Button(Name = "@dataExist?\"该类型已存在\":\"添加\""), BoxGroup("Add"), DisableIf("dataExist", true)]
        private void AddButton()
        {
            if (dataExist)
                return;

            SoundDesc[] newDatas = new SoundDesc[datas.Length + 1];
            datas.CopyTo(newDatas, 0);
            newDatas[datas.Length] = new SoundDesc(addType, addName);
            datas = newDatas;
        }

        private bool dataExist
        {
            get
            {
                foreach (var data in datas)
                {
                    if (data.pointerType == addType)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
#endif
        /// <summary>
        /// 各点击类型对应音效资源名称
        /// </summary>
        [SerializeField, LabelText("音效数据描述")] [ListDrawerSettings(HideAddButton = true)]
        private SoundDesc[] datas = new SoundDesc[] { };

        private bool TryGet(POINTER_TYPE type, out string name)
        {
            name = string.Empty;

            if (datas.Length > 0)
            {
                foreach (var data in datas)
                {
                    if (data.pointerType == type)
                    {
                        name = data.name;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 播放声音
        /// </summary>
        public void Play(POINTER_TYPE type)
        {
            if (Mute)
                return;

            string name;
            if (TryGet(type, out name))
            {
                // Debug.Log(string.Format("Play Sound : {0} | {1}", type, name));
            }
        }
    }
}