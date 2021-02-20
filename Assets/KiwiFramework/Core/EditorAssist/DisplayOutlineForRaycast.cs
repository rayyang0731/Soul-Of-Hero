using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
namespace KiwiFramework.Core
{
    [ExecuteInEditMode]
    public class DisplayOutlineForRaycast : MonoBehaviour
    {
        private static readonly Vector3[] Cornets = new Vector3[4];

        private void OnDrawGizmos()
        {
            foreach (var graphic in FindObjectsOfType<Graphic>())
            {
                if (!graphic.raycastTarget) continue;

                var rt = graphic.rectTransform;
                rt.GetWorldCorners(Cornets);
                Gizmos.color = Color.cyan;
                var size = Cornets[3] - Cornets[1];
                var pos = rt.position;
                for (var i = 0; i < 4; i++)
                {
                    size.x += 0.01f;
                    size.y += 0.01f;
                    Gizmos.DrawWireCube(pos, size);
                }
            }
        }
    }
}
#endif