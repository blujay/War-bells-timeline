using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Threeyes.EventPlayer
{
    /// <summary>
    /// Delay Invoke Play Event
    /// </summary>
    public class DelayEventPlayer : CoroutineEventPlayerBase
    {

        #region Property & Field

        [Header("Delay Setting")]
        [Tooltip("Only work when larger than 0")]
        public float defaultDelayTime = -1;

        #endregion

        #region Method

        protected override void PlayFunc()
        {
            if (defaultDelayTime > 0)
                DelayPlay(defaultDelayTime);
            else
                base.PlayFunc();
        }
        protected override void StopFunc()
        {
            TryStopCoroutine();
            base.StopFunc();
        }

        public void DelayPlay(float delayTime)
        {
            TryStopCoroutine();
            cacheEnum = CoroutineManager.StartCoroutineEx(IEDelayPlay(delayTime));
        }

        IEnumerator IEDelayPlay(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            base.PlayFunc();
        }

        #endregion

        #region Helper Method

#if UNITY_EDITOR

        static string instName = "DelayEP ";
        [MenuItem("GameObject/EventPlayers/DelayEventPlayer", false, 2)]
        public static void CreateDelayEventPlayer()
        {
            CreateObj<DelayEventPlayer>(instName);
        }

        [MenuItem("GameObject/EventPlayers/DelayEventPlayer Child", false, 3)]
        public static void CreateDelayEventPlayerChild()
        {
            CreateObjChild<DelayEventPlayer>(instName);
        }
#endif

        #endregion

    }
}