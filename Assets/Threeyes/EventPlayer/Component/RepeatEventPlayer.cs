using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Threeyes.EventPlayer
{
    /// <summary>
    /// Repeat Invoke Play Event
    /// </summary>
    public class RepeatEventPlayer : CoroutineEventPlayerBase
    {

        #region Property & Field

        [Header("Repeat Setting")]

        [Tooltip("repeat deltaTime, Only work when larger than 0")]
        public float replayDeltaTime = -1;
        [Tooltip("Total repeat time, if set it to less than 0, it will never stop")]
        public float defaultDuration = -1;

        bool isRepeatPlaying = true;

        #endregion

        #region Method

        protected override void PlayFunc()
        {
            if (replayDeltaTime > 0)
                RepeatPlay(true);
            else
                base.PlayFunc();
        }
        protected override void StopFunc()
        {
            if (replayDeltaTime > 0)
                RepeatPlay(false);
            base.StopFunc();
        }


        public void RepeatPlay(bool isPlay)
        {
            isRepeatPlaying = isPlay;
            if (isPlay)
            {
                isRepeatPlaying = true;
                TryStopCoroutine();
                cacheEnum = CoroutineManager.StartCoroutineEx(IERepeatPlay());
            }
            else
            {
                TryStopCoroutine();
                isRepeatPlaying = false;
                base.StopFunc();
            }
        }

        IEnumerator IERepeatPlay()
        {
            float startTime = Time.time;
            while (isRepeatPlaying)
            {
                if (defaultDuration > 0)
                {
                    if (Time.time - startTime > defaultDuration)
                        RepeatPlay(false);
                }

                base.PlayFunc();
                yield return new WaitForSeconds(replayDeltaTime);
            }
        }

        #endregion

        #region Helper Method

#if UNITY_EDITOR

        static string instName = "RepeatEP ";
        [MenuItem("GameObject/EventPlayers/RepeatEventPlayer", false, 4)]
        public static void CreateDelayEventPlayer()
        {
            CreateObj<RepeatEventPlayer>(instName);
        }

        [MenuItem("GameObject/EventPlayers/RepeatEventPlayer Child", false, 5)]
        public static void CreateDelayEventPlayerChild()
        {
            CreateObjChild<RepeatEventPlayer>(instName);
        }
#endif

        #endregion

    }

}