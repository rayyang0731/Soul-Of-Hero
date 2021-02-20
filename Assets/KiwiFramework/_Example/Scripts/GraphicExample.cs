using System.Collections;
using System.Collections.Generic;
using KiwiFramework.UI;
using UnityEngine;

namespace KiwiFramework.Example
{
    public class GraphicExample : MonoBehaviour
    {
        public UIImage UIImage;
        public UIText UIText;

        private void Start()
        {
            InvokeRepeating("ChangeState", 2, 2);
            InvokeRepeating("ChangeGray", 3, 3);
        }

        void ChangeState()
        {
            UIImage.SetState(UIImage.CurrentState == 0 ? 1 : 0);
            UIText.SetState(UIText.CurrentState == 0 ? 1 : 0);
        }

        private bool gray;

        void ChangeGray()
        {
            gray = !gray;
            UIImage.SetGray(gray);
            UIText.SetGray(!gray);
        }
    }
}