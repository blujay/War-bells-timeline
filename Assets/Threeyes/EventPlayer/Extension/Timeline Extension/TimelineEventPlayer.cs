using UnityEngine.Events;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Threeyes.EventPlayer
{
    public class TimelineEventPlayer : EventPlayer
    {

        #region Property & Field

        [Header("Timeline Setting")]
        public FloatEvent onProcessFrame;

        [HideInInspector]
        public PlayableInfo playableInfo = new PlayableInfo();

        #endregion

        #region Method

        public void OnProcessFrame(float percent)
        {
            if (IsReverse)//Reverse
                percent = 1 - percent;
            onProcessFrame.Invoke(percent);
        }

        #endregion

        #region Helper Method

#if UNITY_EDITOR

        static string instName = "TimelineEP ";
        [MenuItem("GameObject/EventPlayers/TimelineEventPlayer", false, 8)]
        public static void CreateDelayEventPlayer()
        {
            CreateObj<TimelineEventPlayer>(instName);
        }

        [MenuItem("GameObject/EventPlayers/TimelineEventPlayer Child", false, 9)]
        public static void CreateDelayEventPlayerChild()
        {
            CreateObjChild<TimelineEventPlayer>(instName);
        }

#endif

        #endregion

    }

    [System.Serializable]
    public class FloatEvent : UnityEvent<float>
    {
    }
}