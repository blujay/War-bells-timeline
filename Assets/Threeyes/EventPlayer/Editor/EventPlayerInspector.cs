#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Threeyes.EventPlayer
{

    [CanEditMultipleObjects]
    [CustomEditor(typeof(EventPlayer), true)]//editorForChildClasses
    public class EventPlayerInspector : Editor
    {
        private EventPlayer _target;

        void OnEnable()
        {
            _target = (EventPlayer)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CommonDrawer(_target);
        }

        public static void CommonDrawer<T>(T ep) where T : EventPlayer
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Play"))
            {
                ep.Play();
            }
            if (GUILayout.Button("Stop"))
            {
                ep.Stop();
            }
            GUILayout.EndHorizontal();

            EventPlayer.RefreshEditor();
        }
    }

}

#endif