using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

using Threeyes.Extension;
namespace Threeyes.EventPlayer
{
    /// <summary>
    /// Manage EventPlayer Children
    /// </summary>
    public class EventPlayerGroup : EventPlayer
    {

        #region Property & Field

        public bool IsIncludeHide { get { return isIncludeHide; } set { isIncludeHide = value; } }
        public bool IsRecursive { get { return isRecursive; } set { isRecursive = value; } }

        [Header("Group Setting")]
        [SerializeField]
        [Tooltip("Is Invoke the child component evenif the GameObject is deActive in Hierarchy")]
        protected bool isIncludeHide = true;
        [SerializeField]
        [Tooltip("Is recursive find the child component")]
        protected bool isRecursive = false;

        #endregion

        #region Method

        protected override void PlayFunc()
        {
            base.PlayFunc();
            ForEachComponent<EventPlayer>((cp) =>
            {
                cp.Play();
            });
        }

        protected override void StopFunc()
        {
            base.StopFunc();
            ForEachComponent<EventPlayer>((cp) =>
            {
                cp.Stop();
            });
        }

        public void ForEachComponent<T>(UnityAction<T> func) where T : Component
        {
            UnityAction<Transform> sonFunc = (tf) =>
            {
                T[] arrT = tf.GetComponents<T>();//In case some GameObject contains multi Component
                foreach (T t in arrT)
                {
                    if (IsIncludeHide)
                    {
                        func(t);
                    }
                    else
                    {
                        if (t.gameObject.activeInHierarchy)
                            func(t);
                    }
                }
            };

            if (IsRecursive)
                transform.Recursive(sonFunc, false);
            else
                transform.ForEachChild(sonFunc, false);
        }

        #endregion

        #region Helper Method

#if UNITY_EDITOR

        static string instName = "EPG ";

        [MenuItem("GameObject/EventPlayers/EventPlayerGroup %#g", false, 100)]
        public static void CreateEventPlayerGroup()
        {
            CreateObj<EventPlayerGroup>(instName);
        }

        [MenuItem("GameObject/EventPlayers/EventPlayerGroup Child &#g", false, 101)]
        public static void CreateEventPlayerGroupChild()
        {
            CreateObjChild<EventPlayerGroup>(instName);
        }

#endif

        #endregion

    }

}