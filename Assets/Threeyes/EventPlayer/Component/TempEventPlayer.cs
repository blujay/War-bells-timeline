using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Threeyes.EventPlayer
{
    /// <summary>
    /// Invoke Play Event for a while, then Invoke Stop Event 
    /// </summary>
    public class TempEventPlayer : CoroutineEventPlayerBase
    {

        #region Property & Field

        [Header("Temp Setting")]
        [Tooltip("Is Invoke Play Event on every frame")]
        public bool isContinuous = false;
        [Tooltip("Only work when larger than 0")]
        public float defaultDuration = -1;

        #endregion


        #region Method

        protected override void PlayFunc()
        {
            if (defaultDuration > 0)
                TempPlay(defaultDuration);
            else
                base.PlayFunc();
        }

        protected override void StopFunc()
        {
            TryStopCoroutine();
            base.StopFunc();
        }

        public void TempPlay(float duration)
        {
            TryStopCoroutine();
            cacheEnum = CoroutineManager.StartCoroutineEx(isContinuous ? IETempContinuousPlay(duration) : IETempPlay(duration));
        }


        IEnumerator IETempPlay(float duration)
        {
            base.PlayFunc();
            yield return new WaitForSeconds(duration);
            base.StopFunc();
        }

        IEnumerator IETempContinuousPlay(float duration)
        {
            float sumTime = duration;
            while (sumTime >= 0)
            {
                sumTime -= Time.deltaTime;
                base.PlayFunc();
                yield return null;
            }
            base.StopFunc();
        }

        #endregion

        #region Helper Method

#if UNITY_EDITOR

        static string instName = "TempEP ";
        [MenuItem("GameObject/EventPlayers/TempEventPlayer", false, 6)]
        public static void CreateDelayEventPlayer()
        {
            CreateObj<TempEventPlayer>(instName);
        }

        [MenuItem("GameObject/EventPlayers/TempEventPlayer Child", false, 7)]
        public static void CreateDelayEventPlayerChild()
        {
            CreateObjChild<TempEventPlayer>(instName);
        }
#endif

        #endregion

    }
}