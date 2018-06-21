using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
namespace Threeyes.EventPlayer
{
    [Serializable]
    public class EventPlayerBehaviour : PlayableBehaviour
    {
        public EventPlayer eventPlayer;

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if (eventPlayer)
                eventPlayer.Play();
        }
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            if (eventPlayer)
                eventPlayer.Stop();
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (eventPlayer && eventPlayer is TimelineEventPlayer)
            {
                TimelineEventPlayer timelineEventPlayer = eventPlayer as TimelineEventPlayer;
                if (timelineEventPlayer)
                {
                    //Set Data
                    PlayableInfo playableInfo = timelineEventPlayer.playableInfo;
                    playableInfo.time = playable.GetTime();
                    playableInfo.duration = playable.GetDuration();

                    timelineEventPlayer.onProcessFrame.Invoke(playableInfo.percent);

#if UNITY_EDITOR
                    EventPlayer.RefreshEditor();
#endif
                }
            }
        }
    }

    [System.Serializable]
    public class PlayableInfo
    {
        public double time;
        public double duration;
        public float percent { get { return duration > 0 ? (float)(time / duration) : 0; } }
    }

}
