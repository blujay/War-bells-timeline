using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
namespace Threeyes.EventPlayer
{

    [TrackColor(0f, 1f, 0f)]
    [TrackClipType(typeof(EventPlayerClip))]
    public class EventPlayerTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            //Update clip displayName
            foreach (TimelineClip clip in GetClips())
            {
                EventPlayerClip eventPlayerClip = clip.asset as EventPlayerClip;
                EventPlayer eventPlayer = eventPlayerClip.eventPlayer.Resolve(graph.GetResolver());
                if (eventPlayer)
                {
                    clip.displayName = eventPlayer.name;
                }
                else
                {
                    clip.displayName = "(Null)";
                }
            }
            return ScriptPlayable<EventPlayerMixerBehaviour>.Create(graph, inputCount);
        }

        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)//Invoke when drag something to the Track
        {
            base.GatherProperties(director, driver);
        }
    }
}